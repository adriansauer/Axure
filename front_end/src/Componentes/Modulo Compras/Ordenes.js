import React, { Component } from "react";
import api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";
class Ordenes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      buscador: "",
      nombreSelector: "Pendiente",
      ordenes: null,
    };
  }
  async componentDidMount() {
    try {
      const request = await api.ordenes_compra.get();
      this.setState({ ordenes: request.data });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  render() {
    return (
      <div className="Ordenes">
        <Notificacion />

        <div className="row ">
          <div className="col-md-6 mr-auto pl-0">
            {/**Un buscador de ordenes */}
            <div className="col-sm-12 pl-0">
              <div className="input-group mb-3">
                <input
                  type="text"
                  className="form-control buscador"
                  aria-label="Busqueda"
                  placeholder="Busqueda por proveedor..."
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
                      href="#pendientes"
                      onClick={() =>
                        this.setState({ nombreSelector: "Pendiente" })
                      }
                    >
                      Pendiente
                    </a>
                    <a
                      className="dropdown-item"
                      href="#enProceso"
                      onClick={() =>
                        this.setState({ nombreSelector: "En Proceso" })
                      }
                    >
                      En Proceso
                    </a>
                    <a
                      className="dropdown-item"
                      href="#terminado"
                      onClick={() =>
                        this.setState({ nombreSelector: "Terminado" })
                      }
                    >
                      Terminado
                    </a>
                    <a
                      className="dropdown-item"
                      href="#cancelado"
                      onClick={() =>
                        this.setState({ nombreSelector: "Cancelado" })
                      }
                    >
                      Cancelado
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
            <thead className="tableHeader">
              <tr>
                <th scope="col">Numero</th>
                <th scope="col">Fecha</th>
                <th scope="col">Proveedor</th>
                <th scope="col">Estado</th>                
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.ordenes !== null
                ? this.state.ordenes
                    .filter((p) => p.Status === this.state.nombreSelector)
                    .filter(
                      (p) =>
                        p.ProviderName.toLowerCase().indexOf(
                          this.state.buscador.toLowerCase()
                        ) !== -1
                    )
                    .map((c) => (
                      <tr key={c.Id}>
                        <td>{c.Number}</td>
                        <td>
                          {c.Day}/{c.Month}/{c.Year}
                        </td>
                        <td>{c.ProviderName}</td>
                        <td>{c.Status}</td>
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

export default Ordenes;
