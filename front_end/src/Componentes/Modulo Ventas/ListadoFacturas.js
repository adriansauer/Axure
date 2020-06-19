import React, { Component } from "react";
import api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";
class ListadoFacturas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      facturas: null,
      fecha: new Date(1000, 1, 1),
    };
  }
  async componentDidMount() {
    try {
      const facturas = await api.factura.get();
      console.log(facturas);
      this.setState({ facturas: facturas.data });
    } catch (error) {
      notify("Error al intentar conectarse con la base de datos", "danger");
    }
  }
  componentDidUpdate() {
    if (isNaN(this.state.fecha)) {
      this.setState({
        fecha: new Date(1000, 1, 1),
      });
    }
  }
  render() {
    return (
      <div className="listadoFacturas">
        <Notificacion />
        <div className="row">
          <div className="col-md-2">
            <label>Filtrar facturas a partir del:</label>
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
                <th scope="col">Numero</th>
                <th scope="col">Cliente</th>
                <th scope="col">Estado</th>
                <th scope="col">Condicion de venta</th>
                <th scope="col">Total</th>
                <th scope="col">IVA</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.facturas != null
                ? this.state.facturas
                    .filter(
                      (o) =>
                        new Date(o.Year, o.Month - 1, o.Day) >= this.state.fecha
                    )
                    .map((f) => (
                      <tr key={f.Id}>
                        <td>
                          {f.Day}/{f.Month}/{f.Year}
                        </td>

                        <td>{f.InvoiceNumber}</td>
                        <td>
                          {f.ClientName}-{f.ClientRUC}
                        </td>

                        <td>{f.Status}</td>
                        <td>{f.SaleCondition}</td>
                        <td>{f.Total}</td>
                        <td>{f.TaxTotal}</td>
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
export default ListadoFacturas;
