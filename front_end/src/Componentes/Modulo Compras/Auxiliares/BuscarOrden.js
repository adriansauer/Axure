import React, { Component } from "react";
import FeaturedPlayListIcon from "@material-ui/icons/FeaturedPlayList";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";
import CrearFactura from "./CrearFactura.js";
class BuscarOrden extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ordenes: [],
      filtro: "Pendiente",
      proveedores: [],
      proveedor: {},
      proveedorNombre: "",
      proveedorElegido: false,
      ordenSeleccionada: null,
      crearFacturaVisible: false,
    };
  }
  async componentDidMount() {
    await this.actualizar();
  }

  async actualizar() {
    try {
      const ordenes = await api.ordenes_compra.get();
      const proveedores = await api.proveedores.get();

      this.setState({
        ordenes: ordenes.data,
        proveedores: proveedores.data,
      });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  ocultar() {
    this.setState({ crearFacturaVisible: false });
  }
  buscarProveedor(e) {
    this.setState({
      proveedorNombre: e.target.value,
      proveedorElegido: false,
    });

    this.toggleShow("dropdown-proveedor");
  }
  toggleShow(param) {
    if (document.getElementById(param) !== null) {
      document.getElementById(param).classList.toggle("show");
    }
  }
  seleccionarProveedor(proveedor) {
    this.setState({
      proveedor: proveedor,
      proveedorNombre: proveedor.Name,
      proveedorElegido: true,
    });

    this.toggleShow("dropdown-cliente");
  }
  crearFactura(orden){
      this.setState({
        ordenSeleccionada:orden,
        crearFacturaVisible:true
      })
  }
  render() {
    if (this.state.crearFacturaVisible) {
      //Debo pasarle la orden
      //y una funcion para retroceder
      return (
        <CrearFactura
          retroceder={this.ocultar.bind(this)}
          orden={this.state.ordenSeleccionada}
        />
      );
    } else {
      return (
        <div className="BuscarOrden">
          <Notificacion />
          <div className="row">
            <div className="col-md-3">
              <label>Ordenes del Proveedor:</label>
            </div>
            <div className="col-md-4">
              <div className="dropdown">
                <input
                  type="text"
                  className="form-control"
                  placeholder="Proveedor"
                  required="required"
                  value={this.state.proveedorNombre}
                  onChange={(e) => this.buscarProveedor(e)}
                />
                <div className="dropdown-menu" id="dropdown-proveedor">
                  {this.state.proveedorNombre !== "" && !this.state.proveedorElegido
                    ? this.state.proveedores
                        .filter(
                          (proveedor) =>
                          proveedor.Name.toLowerCase().indexOf(
                              this.state.proveedorNombre.toLowerCase()
                            ) !== -1
                        )
                        .map((p) => (
                          <a
                            className="dropdown-item"
                            key={p.Id}
                            onClick={() => this.seleccionarProveedor(p)}
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
                    <th scope="col">Proveedor</th>
                    <th scope="col">Fecha</th>
                    <th scope="col">Acciones</th>
                  </tr>
                </thead>
                <tbody className="tableBody">
                  {this.state.proveedorElegido
                    ? this.state.ordenes
                        .filter((o) => o.ProviderId === this.state.proveedor.Id && (o.Status === "Pendiente" || o.Status === "Procesando"))
                        .map((o) => (
                          <tr key={o.Id}>
                            <td>{o.Number}</td>
                            {this.state.proveedores
                              .filter((c) => c.Id === o.ProviderId)
                              .map((c) => (
                                <td key={c.Id}>{c.Name}</td>
                              ))}
                            <td>
                              {o.Day}/{o.Month}/{o.Year}
                            </td>
                            <td>
                              <FeaturedPlayListIcon
                                onClick={() => this.crearFactura(o)}
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
}

export default BuscarOrden;
