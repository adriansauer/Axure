import React, { Component } from "react";
import ViewIcon from "@material-ui/icons/ViewList"
import api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";
import Detalles from "./Modales/FacturaDetalles.js"
class Facturas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreSelector: "Pagada",
      verDetalles: false,
      buscador: "",
      facturas: null,
      factura: {
        Id: "",
        ProviderId: "",
        PurchaseOrderId: "",
        Status: "",
        InvoiceNumber: "",
        ProviderName: "",
        ProviderRUC: "",
        ProviderAddress: "",
        Total: 0,
        TaxTotal: 0

      },
      fecha: new Date(1000, 1, 1),
    };
  }
  async componentDidMount() {
    try {
      const facturas = await api.factura_compra.get();
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

  seleccionarFactura(fc){
    this.setState({
      factura: fc,
    })
  }
  ocultarModales() {
    this.setState({ 
      verDetalles: false,
    });
    this.componentDidMount();
  }

  mostrarDetalle(fc){
    const aux = this.state.factura;
    if (aux.Id !== ""){
      this.setState({
        factura:fc,
        verDetalles:true
      });
    }
      this.setState({
        factura:fc,
      });
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
      <div className="listadoFacturas">
        <Notificacion />
        <Detalles
          visible={this.state.verDetalles}
          ocultar={this.ocultarModales.bind(this)}
          factura={this.state.factura}
        />
        <div className="row">
          <div className="col-md-1">
            <label>Desde:</label>
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
          <div className="col-sm-4 pl-0">
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
                      href="#pagadas"
                      onClick={() =>
                        this.setState({ nombreSelector: "Pagada" })
                      }
                    >
                      Pagadas
                    </a>
                    <a
                      className="dropdown-item"
                      href="#terminado"
                      onClick={() =>
                        this.setState({ nombreSelector: "Completado" })
                      }
                    >
                      Completado
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
        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
            <thead className="tableHeader">
              <tr>
                <th scope="col">Numero de Factura</th>
                <th scope="col">Fecha</th>
                <th scope="col">Proveedor</th>
                <th scope="col">Estado</th>
                <th scope="col">Total</th>
                <th scope="col">Total IVA</th>
                <th scope="col">Ver</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.facturas != null
                ? this.state.facturas
                    .filter((o) =>new Date(o.Year, o.Month - 1, o.Day) >= this.state.fecha
                    )
                    .filter((x) => x.Status === this.state.nombreSelector)
                    .filter(
                        (p) =>
                          p.ProviderName.toLowerCase().indexOf(
                            this.state.buscador.toLowerCase()
                          ) !== -1
                      )
                    .map((f) => (
                      <tr key={f.Id}>
                        <td>{f.InvoiceNumber}</td>
                        <td>
                          {f.Day}/{f.Month}/{f.Year}
                        </td>
                        <td>{f.ProviderName}</td>
                        <td>{f.Status}</td>
                        <td>{this.formato("es-PY","PYG",f.Total)}</td>
                        <td>{this.formato("es-PY","PYG",f.TaxTotal)}</td>
                        <td>
                            <ViewIcon
                            onClick={() => this.mostrarDetalle(f)}/>
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
export default Facturas;