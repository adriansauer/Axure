import React, { Component } from "react";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import AgregarCliente from "./Modales/AgregarCliente.js";
class Clientes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreSelector: "Todos",
      buscador: "",
      agregarClienteVisible: false,
    };
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
  ocultarModales() {
    this.setState({ agregarClienteVisible: false });
  }
  render() {
    return (
      <div className="Container">
        <AgregarCliente
          visible={this.state.agregarClienteVisible}
          ocultar={this.ocultarModales.bind(this)}
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
                  aria-label="Busqueda"
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
                      href="#"
                      onClick={() => this.mostrarAlDia()}
                    >
                      Al día
                    </a>
                    <a
                      className="dropdown-item"
                      href="#"
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
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              <tr>
                <td>Julio Caceres</td>
                <td>Encarnacion</td>
                <td>50974651</td>

                <td>
                  <EditIcon />
                  <DeleteIcon />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default Clientes;
