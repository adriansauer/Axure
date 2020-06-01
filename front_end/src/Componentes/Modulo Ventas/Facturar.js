import React, { Component } from "react";
import api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion";
import FeaturedPlayListIcon from "@material-ui/icons/FeaturedPlayList";
import FacturarModal from "./Modales/FacturarModal.js";
class Facturar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ordenes: [],
      filtro: "Pendiente",
      clientes: [],
      cliente: {},
      clienteNombre: "",
      clienteElegido: false,
      empleados: [],
      facturarModalVisible: false,
      ordenSeleccionada: null,
    };
  }
  async componentDidMount() {
    await this.actualizar();
  }

  ocutlarModales() {
    this.setState({ facturarModalVisible: false });
    this.actualizar();
  }
  async actualizar() {
    try {
      const ordenes = await api.ordenes_venta.get();
      const clientes = await api.clientes.get();
      const empleados = await api.empleados.get();

      this.setState({
        ordenes: ordenes.data,
        clientes: clientes.data,
        empleados: empleados.data,
      });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }

  buscarCliente(e) {
    this.setState({
      clienteNombre: e.target.value,
      clienteElegido: false,
    });

    this.toggleShow("dropdown-cliente");
  }
  toggleShow(param) {
    if (document.getElementById(param) !== null) {
      document.getElementById(param).classList.toggle("show");
    }
  }
  seleccionarCliente(cliente) {
    this.setState({
      cliente: cliente,
      clienteNombre: cliente.Name,
      clienteElegido: true,
    });

    this.toggleShow("dropdown-cliente");
  }
  async abrirModal(o) {
    try {
      const orden = await api.ordenes_venta.getDetalles(o.Id);
      await this.setState({ ordenSeleccionada: orden.data });
      this.setState({ facturarModalVisible: true });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  render() {
    return (
      <div className="Facturar">
        <FacturarModal
          ocultar={this.ocutlarModales.bind(this)}
          orden={this.state.ordenSeleccionada}
          visible={this.state.facturarModalVisible}
        />
        <Notificacion />

        <div className="row">
          <div className="col-md-2">
            <label>Ordenes del cliente:</label>
          </div>
          <div className="col-md-4">
            <div className="dropdown">
              <input
                type="text"
                className="form-control"
                placeholder="Cliente"
                required="required"
                value={this.state.clienteNombre}
                onChange={(e) => this.buscarCliente(e)}
              />
              <div className="dropdown-menu" id="dropdown-cliente">
                {this.state.clienteNombre !== "" && !this.state.clienteElegido
                  ? this.state.clientes
                      .filter(
                        (cliente) =>
                          cliente.Name.toLowerCase().indexOf(
                            this.state.clienteNombre.toLowerCase()
                          ) !== -1
                      )
                      .map((p) => (
                        <a
                          className="dropdown-item"
                          key={p.Id}
                          onClick={() => this.seleccionarCliente(p)}
                          href="#selected"
                        >
                          {p.Name},{p.RUC}
                        </a>
                      ))
                  : null}
              </div>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-md-6">
            <table
              className="table table-hover table"
              style={{ marginTop: "3%" }}
            >
              <thead className="tableHeader">
                <tr>
                  <th scope="col">Numero de orden</th>
                  <th scope="col">Encargado</th>
                  <th scope="col">Cliente</th>
                  <th scope="col">Fecha</th>
                  <th scope="col">Acciones</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {this.state.clienteElegido
                  ? this.state.ordenes
                      .filter((o) => o.ClientId === this.state.cliente.Id)
                      .map((o) => (
                        <tr key={o.Id}>
                          <td>{o.OrderNumber}</td>
                          {this.state.empleados
                            .filter((e) => e.Id === o.EmployeeId)
                            .map((e) => (
                              <td key={e.Id}>{e.Name}</td>
                            ))}
                          {this.state.clientes
                            .filter((c) => c.Id === o.ClientId)
                            .map((c) => (
                              <td key={c.Id}>{c.Name}</td>
                            ))}
                          <td>
                            {o.Day}/{o.Month}/{o.Year}
                          </td>
                          <td>
                            <FeaturedPlayListIcon
                              onClick={() => this.abrirModal(o)}
                            />
                          </td>
                        </tr>
                      ))
                  : null}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    );
  }
}
export default Facturar;
