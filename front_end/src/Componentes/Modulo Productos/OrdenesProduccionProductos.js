import React, { Component } from "react";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import OrdenDetalles from "./Modales/ordenDetalles.js";
import DeleteIcon from "@material-ui/icons/Delete";
import ProductosFaltantes from "./Modales/ProductosFaltantes.js";
import Notificacion, { notify } from "../Notificacion";
class OrdenesProduccionProductos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ordenes: [],
      ordenSeleccionada: null,
      detallesVisible: false,
      productosFaltantesVisible: false,
      empleados: null,
      fecha: new Date(1000, 1, 1),
      /**Pendiente,En Proceso,Terminado,Cancelado */
      filtro: "Pendiente",
      productosFaltantes: null,
    };
  }
  async componentDidMount() {
    const request = await api.ordenProduccion.get();
    const request2 = await api.empleados.get();
    this.setState({ ordenes: request.data, empleados: request2.data });
  }
  componentDidUpdate() {
    if (isNaN(this.state.fecha)) {
      this.setState({
        fecha: new Date(1000, 1, 1),
      });
    }
  }
  ocultarModales() {
    this.setState({ detallesVisible: false, productosFaltantesVisible: false });
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
  async actualizar() {
    const request = await api.ordenProduccion.get();
    const request2 = await api.empleados.get();
    this.setState({ ordenes: request.data, empleados: request2.data });
  }
  async eliminarOrden(id) {
    const request = await api.ordenProduccion.delete(id);
    if (request.status === 200) {
      notify("La orden ha sido eliminada!", "success");
    } else {
      notify("No es posible eliminar la orden", "danger");
    }
    this.actualizar();
  }
  async cambiarEstado(nuevoEstado, empleadoId, ordenId) {
    const estado = await api.settings.get(nuevoEstado);
    const dato = {
      ProductionStateId: parseInt(estado.data.Value),
      EmployeeId: empleadoId,
    };

    const request = await api.ordenProduccion.cambiarEstado(ordenId, dato);
    if (nuevoEstado === "ID_PRODUCTION_STATE_PROGRESS") {
      if (request.data !== "") {
        notify("Error al intentar modificar el estado de la orden!", "danger");
        this.setState({
          productosFaltantes: request.data.listNotStock,
          productosFaltantesVisible: true,
        });
      } else {
        if (request.status === 200) {
          notify("El estado de la orden ha sido actualizado!", "success");
        }
      }
    } else if (request.status === 200) {
      notify("El estado de la orden ha sido actualizado!", "success");
    }

    this.actualizar();
  }
  render() {
    return (
      <div
        className="ordenesProduccionProducto"
        style={{ overflowY: "scroll" }}
      >
        <Notificacion />
        <OrdenDetalles
          orden={this.state.ordenSeleccionada}
          visible={this.state.detallesVisible}
          ocultar={this.ocultarModales.bind(this)}
        />
        <ProductosFaltantes
          lista={this.state.productosFaltantes}
          visible={this.state.productosFaltantesVisible}
          ocultar={this.ocultarModales.bind(this)}
        />
        <div className="row">
          <div className="col-md-4"></div>
          <button onClick={() => this.setState({ filtro: "Pendiente" })}>
            Pendientes
          </button>
          <button onClick={() => this.setState({ filtro: "En Proceso" })}>
            En proceso
          </button>
          <button onClick={() => this.setState({ filtro: "Terminado" })}>
            Terminadas
          </button>
          <button onClick={() => this.setState({ filtro: "Cancelado" })}>
            Canceladas
          </button>
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
                onChange={(e) => {
                  this.setState({
                    fecha: new Date(e.target.value),
                  });
                }}
              />
            </div>
          </div>
        </div>

        <div style={{ height: "600px", overflowY: "scroll" }}>
          {this.state.ordenes
            .filter((o) => this.state.filtro === o.ProductionState.State)
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
                    <div className="col-md-4">
                      <button onClick={() => this.mostrarDetalles(o.Id)}>
                        Detalles
                      </button>
                      {o.ProductionState.State === "Pendiente" ? (
                        <button
                          onClick={() =>
                            this.cambiarEstado(
                              "ID_PRODUCTION_STATE_PROGRESS",
                              o.EmployeeId,
                              o.Id
                            )
                          }
                        >
                          Procesar orden
                        </button>
                      ) : o.ProductionState.State === "En Proceso" ? (
                        <button
                          onClick={() =>
                            this.cambiarEstado(
                              "ID_PRODUCTION_STATE_FINALIZED",
                              o.EmployeeId,
                              o.Id
                            )
                          }
                        >
                          Terminar orden
                        </button>
                      ) : null}
                      {o.ProductionState.State === "Pendiente" ||
                      o.ProductionState.State === "En Proceso" ? (
                        <button
                          onClick={() =>
                            this.cambiarEstado(
                              "ID_PRODUCTION_STATE_CANCELLED",
                              o.EmployeeId,
                              o.Id
                            )
                          }
                        >
                          Cancelar
                        </button>
                      ) : null}
                    </div>
                    <div className="col-md-2">
                      {o.ProductionState.State === "Cancelado" ||
                      o.ProductionState.State === "Terminado" ? (
                        <DeleteIcon
                          className="icono"
                          onClick={() => this.eliminarOrden(o.Id)}
                        />
                      ) : null}
                    </div>
                  </div>
                </div>
              </div>
            ))}
        </div>
      </div>
    );
  }
}
export default OrdenesProduccionProductos;
