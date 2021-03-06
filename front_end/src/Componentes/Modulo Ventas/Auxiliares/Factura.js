import React, { Component } from "react";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";

class Factura extends Component {
  constructor(props) {
    super(props);
    this.state = {
      InvoiceNumber: "",
    };
  }

  componentDidMount() {
    document.getElementById("imprimirbtn").style.display = "none";
  }
  printDiv(nombreDiv) {
    var contenido = document.getElementById(nombreDiv).innerHTML;
    var contenidoOriginal = document.body.innerHTML;

    document.body.innerHTML = contenido;

    window.print();

    document.body.innerHTML = contenidoOriginal;
  }
  filtroDeLetras(texto){
    if(texto==""){
      return true;
    }else if(!isNaN(texto[texto.length-1])){
      return true;
    }else{
      return false;
    }
  }
  formato(locales, moneda, numero){
    var format = new Intl.NumberFormat(locales,{
      style: "currency",
      currency: moneda,
      minimumFractionDigits:0
    }).format(numero);
    return format;
  }
  async facturar() {
    const factura = {
      OrderSaleId: this.props.orden.Id,
      EmployeeId: this.props.factura.EmployeeDTO.Id,
      ClientId: this.props.factura.ClientDTO.Id,
      SaleCondition: this.props.factura.SaleCondition,
      InvoiceNumber: this.state.InvoiceNumber,
      Day: this.props.factura.Day,
      Month: this.props.factura.Month,
      Year: this.props.factura.Year,
      ListItems: this.props.factura.ListItems.map((p) => {
        return {
          ProductId: p.ProductId,
          Quantity: p.QuantitySale,
        };
      }),
    };
    if (this.state.InvoiceNumber === "") {
      notify("Rellene el numero de factura", "warning");
    } else {
      if (this.props.factura.ValidationCode === 0) {
        try {
          const request = await api.factura.create(factura);
          if (request.status === 200) {
            document.getElementById("facturarbtn").style.display = "none";
            document.getElementById("imprimirbtn").style.display = "inline";
            notify("Factura creada exitosamente", "success");
          } else {
            notify("Error al intentar crear la factura", "warning");
          }
        } catch (error) {
          notify("Error al intentar crear la factura", "danger");
        }
      } else if (this.props.factura.ValidationCode === 1) {
        notify("El cliente no cuenta con credito disponible", "warning");
      } else if (this.props.factura.ValidationCode === 2) {
        notify("No hay productos suficientes en stock", "warning");
      }
    }
  }

  render() {
    return (
      <div className="Factura">
        <Notificacion />
        <div className="CrearFacturaHeader row">
          <div className="col-md-12">
            <ArrowBackIcon
              onClick={() => this.props.retroceder()}
              style={{ height: "50px", width: "50px" }}
            />
          </div>
        </div>
        <div id="imprimir">
          <div className="row">
            <div className="col-md-2">
              <b>Numero de factura:</b>
            </div>

            <div className="col-md-2">
              <input
                autoComplete="off"
                type="text"
                id="numFactura"
                className="form-control"
                style={(this.state.InvoiceNumber==="")?{borderColor:"red"}:{borderColor:"green"}}
                value={this.state.InvoiceNumber}
                maxLength="100"
                onChange={(e) =>
                  (this.filtroDeLetras(e.target.value))?
                  this.setState({ InvoiceNumber: e.target.value }):null
                }
              />
            </div>
          </div>

          <div className="row">
            <div className="col-md-6">
              <label>
                <b>NOMBRE O RAZON SOCIAL</b>:{this.props.factura.ClientDTO.Name}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <label>
                <b>CONDICION DE VENTA</b> :{this.props.factura.SaleCondition}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <label>
                <b> DIRECCION</b>:{this.props.factura.ClientDTO.Address}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-10">
              <label>
                <b>RUC</b>:{this.props.factura.ClientDTO.RUC}
              </label>
            </div>
          </div>
          <div className="row">
            <table className="table table-hover table">
              <thead className="tableHeader">
                <tr>
                  <th scope="col">CANT.</th>
                  <th scope="col">CONCEPTO</th>
                  <th scope="col">PRECIO UNITARIO</th>
                  <th scope="col">EXCENTAS</th>
                  <th>5%</th>
                  <th>10%</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {this.props.factura.ListItems.map((i) => (
                  <tr key={i.Id}>
                    <td>{i.QuantitySale}</td>
                    <td>
                      {i.Name} {i.Description}
                    </td>
                    <td>{this.formato("es-PY","PYG",i.UnitPrice)}</td>
                    <td></td>
                    <td></td>
                    <td>{this.formato("es-PY","PYG",i.Total)}</td>
                  </tr>
                ))}
                <tr>
                  <td>SUBTOTAL</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.formato("es-PY","PYG",this.props.factura.TaxTotal)}</td>
                </tr>
                <tr>
                  <td>TOTAL A PAGAR</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.formato("es-PY","PYG",this.props.factura.Total)}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-md-8"></div>
          <div className="col-md-2">
            <button id="imprimirbtn" onClick={() => this.printDiv("imprimir")}>
              Imprimir
            </button>
            <button
              className="btn-primary"
              id="facturarbtn"
              onClick={() => this.facturar()}
            >
              Facturar
            </button>
          </div>
        </div>
      </div>
    );
  }
}
export default Factura;
