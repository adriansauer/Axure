import React, { Component } from "react";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import VisibilityIcon from "@material-ui/icons/Visibility";
import DeleteIcon from "@material-ui/icons/Delete";
import Detalle from "./Modales/movimientoDetalle.js";

class Movimientos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      movimientos: [],
      movimientoSeleccionado: null,
      detallesVisible: false,
      empleados: null,
      fecha: new Date(1000, 1, 1),
      /**Pendiente,En Proceso,Terminado,Cancelado */
      filtro: "Pendiente",
    };
  }
  async componentDidMount() {
    const request = await api.ingreso_egreso.get();
    const request2 = await api.empleados.get();
    this.setState({ movimientos: request.data, empleados: request2.data });
  }
  componentDidUpdate() {
    if (isNaN(this.state.fecha)) {
      this.setState({
        fecha: new Date(1000, 1, 1),
      });
    }
  }
  ocultarModales() {
    this.setState({ detallesVisible: false });
  }
  async mostrarDetalles(movimiento) {
    const request = await api.ingreso_egreso.getMovimientoDetalle(movimiento.Id);
   
    this.setState({
      movimientoSeleccionado: {
        Quantity: movimiento.Quantity,
        Observation:movimiento.Observation,
        ListDetails:request.data
      },
    });
    this.setState({
      detallesVisible: true,
    });
  }
  async delete(id) {
    await api.ingreso_egreso.delete(id);
    const request2 = await api.ingreso_egreso.get();
    this.setState({ movimientos: request2.data });
  }
  render() {
    return (
      <div className="productosBaja">
        <Detalle
          movimiento={this.state.movimientoSeleccionado}
          ocultar={this.ocultarModales.bind(this)}
          visible={this.state.detallesVisible}
        />
        <div className="row title-wrapper py-3">
          <div className="col-sm-12 bg-title">
            <label className="m-auto title-label">Movimientos</label>
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <div className="input-group mb-3">
              <div className="input-group-prepend">
                <span className="input-group-text" id="basic-addon1">Filtrar por fecha: </span>
              </div>
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
        <div className="row p-3">
          <table className="table table-hover table">
            <thead className="tableHeader">
              <tr>
                <th scope="col">#</th>
                <th scope="col">Fecha</th>
                <th scope="col">Tipo</th>
                <th scope="col">Encargado</th>
                <th scope="col">Deposito</th>
                <th scope="col">Costo total</th>
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.movimientos
                .filter(
                  (o) =>
                    new Date(o.Year, o.Month - 1, o.Day) >= this.state.fecha
                )
                .map((p) => (
                  <tr key={p.Id}>
                    <td>{p.Id}</td>
                    <td>
                      {p.Day}/{p.Month}/{p.Year}
                    </td>
                    {p.MovementTypeId === 1 ? (
                      <td>Ingreso</td>
                    ) : (
                      <td>Egreso</td>
                    )}

                    {this.state.empleados
                      .filter((e) => p.EmployeeId === e.Id)
                      .map((e) => (
                        <td key={e.Id}>{e.Name}</td>
                      ))}

                    <td>{p.DepositId}</td>
                    <td>{p.TotalCost}</td>
                    <td>
                      <VisibilityIcon
                        onClick={() => this.mostrarDetalles(p)}
                      />
                      <DeleteIcon onClick={() => this.delete(p.Id)} />
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}
export default Movimientos;
