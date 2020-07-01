import React, { Component } from "react";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import AgregarCliente from "./Modales/AgregarCliente.js";
import EditarCliente from "./Modales/EditarCliente.js";
import "./style.css"
import Api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";


class Clientes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreSelector: "Todos",
      buscador: "",
      agregarClienteVisible: false,
      editarClienteVisible:false,
      clientes: [],
      clienteSeleccionado: {
        Id: 0,
        Name: "",
        Address: "",
        RUC: "",
        Phone: "",
        CreditMaximum: "",
      },
    };
  }
  componentDidMount() {
    this.actualizar();
  }
  async actualizar() {
    try {
      const clientes = await Api.clientes.get();
      this.setState({ clientes: clientes.data });
    } catch (error) {
      notify("No se pudo conectar a la base de datos", "danger");
    }
  }
  mostrarTodos() {
    this.setState({ nombreSelector: "Todos" });
  }
  mostrarAlDia() {
    this.setState({ nombreSelector: "Al dia" });
  }
  mostrarEnMora() {
    this.setState({ nombreSelector: "En mora" });
  }
  async ocultarModales() {
    this.setState({ agregarClienteVisible: false,editarClienteVisible:false });
    await this.actualizar();
  }
  seleccionarCliente(cliente) {
    this.setState({ clienteSeleccionado: cliente });
  }
  async eliminarCliente(cliente) {
    await this.seleccionarCliente(cliente);
    try {
      const request = await Api.clientes.delete(
        this.state.clienteSeleccionado.Id
      );
      if (request.status === 200) {
        notify("Cliente eliminado con exito", "success");
        await this.actualizar();
      } else {
        notify("Error al intentar eliminar el cliente", "danger");
      }
    } catch (error) {
      notify("Error al intentar eliminar el cliente", "danger");
    }
  }
 async  editarCliente(cliente){
    await this.seleccionarCliente(cliente);
    this.setState({editarClienteVisible:true});
  }
  render() {
    return (
      <div className="Container">
        <Notificacion />
        <AgregarCliente
          visible={this.state.agregarClienteVisible}
          ocultar={this.ocultarModales.bind(this)}
        />
        <EditarCliente
          visible={this.state.editarClienteVisible}
          ocultar={this.ocultarModales.bind(this)}
          cliente={this.state.clienteSeleccionado}
        />
        <div className="row ">
          <div className="col-md-6 mr-auto pl-0">
            {/**Un buscador de productos */}
            <div className="col-sm-12 pl-0">
              <div className="input-group mb-3">
                <input
                  type="text"
                  className="form-control buscador"
                  aria-label="Busqueda"
                  placeholder="Busqueda..."
                  value={this.state.buscador}
                  onChange={(e) => {
                    this.setState({ buscador: e.target.value });
                  }}
                />
                <div className="input-group-append">
                  <button
                    className="btn btn-outline-secondary dropdown-toggle"
                    type="button"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >
                    {this.state.nombreSelector}
                  </button>
                  <div className="dropdown-menu">
                    <a
                      className="dropdown-item"
                      href="#todos"
                      onClick={() => this.mostrarTodos()}
                    >
                      Todos
                    </a>
                    <a
                      className="dropdown-item"
                      href="#AlDia"
                      onClick={() => this.mostrarAlDia()}
                    >
                      Al día
                    </a>
                    <a
                      className="dropdown-item"
                      href="#EnMora"
                      onClick={() => this.mostrarEnMora()}
                    >
                      En mora
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <button
            className="btn btn-primary"
            onClick={() => this.setState({ agregarClienteVisible: true })}
          >
            Agregar Cliente
          </button>
        </div>

        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
            <thead className="tableHeader">
              <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Direccion</th>
                <th scope="col">Ruc</th>
                <th scope="col">Telefono</th>
                <th scope="col">Credito total</th>
                <th scope="col">Credito disponible</th>
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.clientes.length !== 0
                ? this.state.clientes
                    .filter(
                      (p) =>
                        p.Name.toLowerCase().indexOf(
                          this.state.buscador.toLowerCase()
                        ) !== -1
                    )
                    .map((c) => (
                      <tr key={c.Id}>
                        <td>{c.Name}</td>
                        <td>{c.Address}</td>
                        <td>{c.RUC}</td>
                        <td>{c.Phone}</td>
                        <td>{c.CreditMaximum}</td>
                        <td>{c.CreditPending}</td>
                        <td>
                          <EditIcon onClick={()=>this.editarCliente(c)} />
                          <DeleteIcon onClick={() => this.eliminarCliente(c)} />
                        </td>
                      </tr>
                    ))
                : null}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default Clientes;
