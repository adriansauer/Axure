import React, { Component } from "react";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import OrdenDetalles from "./Modales/ordenDetalles.js";
class OrdenesProduccionProductos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ordenes: [],
      ordenSeleccionada: null,
      detallesVisible: false,
      empleados: null,
      fecha: new Date(1000, 1, 1),
    };
  }
  async componentDidMount() {
    const request = await api.ordenProduccion.get();
    const request2 = await api.empleados.get();
    this.setState({ ordenes: request.data, empleados: request2.data });
  }
componentDidUpdate(){
  if (isNaN(this.state.fecha)) {
      this.setState({
        fecha:new Date(1000, 1, 1)
      })
    }
}
  ocultarModales() {
    this.setState({ detallesVisible: false });
  }
  async mostrarDetalles(orden) {
    const request = await api.ordenProduccion.ordenDetalles(orden);

    this.setState({
      ordenSeleccionada: request.data,
    });
    this.setState({
      detallesVisible: true,
    });
  }
  render() {
    
    return (
      <div className="ordenesProduccionProducto">
        <OrdenDetalles
          orden={this.state.ordenSeleccionada}
          visible={this.state.detallesVisible}
          ocultar={this.ocultarModales.bind(this)}
        />
        <div className="row">
          <div className="col-md-4"></div>
          <button>Pendientes</button>
          <button>En proceso</button>
          <button>Terminadas</button>
          <button>Canceladas</button>

        </div>
        <div className="row">
          <div className="col-md-2">
            <label>Filtrar ordenes a partir del:</label>
          </div>
          <div className="col-md-2">
            <div className="form-group">
              <input
                type="date"
                name="date"
                id="fecha"
                max="3000-12-31"
                min="1000-01-01"
                className="form-control"
                onChange={(e) =>{
                  this.setState({
                    fecha: new Date(e.target.value)
                })
                }}
              />
            </div>
          </div>
        </div>

        {this.state.ordenes
          .filter(
            (o) => new Date(o.Year, o.Month - 1, o.Day) >= this.state.fecha
          )
          .map((o) => (
            <div className="card " key={o.Id}>
              <div className="card-body carta">
                <div className="row">
                  <h5 className="card-title">Orden Numero: {o.Id}</h5>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <p className="card-text">
                      Estado: {o.ProductionState.State}
                    </p>
                    <p className="card-text">Observacion: {o.Observation}</p>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <p className="card-text ">
                      Fecha: {o.Day}/{o.Month}/{o.Year}
                    </p>
                    <p className="card-text ">
                      Encargado/a:{" "}
                      {this.state.empleados
                        .filter((e) => o.EmployeeId === e.Id)
                        .map((e) => e.Name)}
                    </p>
                  </div>
                  <div className="col-md-6">
                    <button onClick={() => this.mostrarDetalles(o.Id)}>
                      Detalles
                    </button>
                  </div>
                </div>
              </div>
            </div>
          ))}
      </div>
    );
  }
}
export default OrdenesProduccionProductos;
