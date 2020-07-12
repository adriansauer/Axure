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
  
  formato(locales, moneda, numero){
    var format = new Intl.NumberFormat(locales,{
      style: "currency",
      currency: moneda,
      minimumFractionDigits:0
    }).format(numero);
    return format;
  }
  render() {
    return (
      <div className="productosBaja">
        <Detalle
          movimiento={this.state.movimientoSeleccionado}
          ocultar={this.ocultarModales.bind(this)}
          visible={this.state.detallesVisible}
        />

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
        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
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
                    <td>{this.formato("es-PY","PYG",p.TotalCost)}</td>
                    <td>
                      <VisibilityIcon
                        onClick={() => this.mostrarDetalles(p)}
                      />
                      
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
