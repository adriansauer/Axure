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
  format(n, sep, decimals) {
    sep = sep || "."; // Default to period as decimal separator
    decimals = decimals || 2; // Default to 2 decimals

    return (
      n.toLocaleString().split(sep)[0] + sep + n.toFixed(decimals).split(sep)[1]
    );
  }
  /*async facturar() {
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
  }*/

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
                placeholder={/*this.state.InvoiceNumber*/100000}
                maxLength="100"
              />
            </div>
          </div>

          <div className="row">
            <div className="col-md-6">
              <label>
                <b>NOMBRE O RAZON SOCIAL</b>:{/*this.props.factura.ClientDTO.Name*/"Nombre"}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <label>
                <b>CONDICION DE COMPRA</b> :{/*this.props.factura.SaleCondition*/"CONTADO"}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <label>
                <b> DIRECCION</b>:{/*this.props.factura.ClientDTO.Address*/"DIREC"}
              </label>
            </div>
          </div>
          <div className="row">
            <div className="col-md-10">
              <label>
                <b>RUC</b>:{/*this.props.factura.ClientDTO.RUC*/"454654-25"}
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
                {
                  <tr key={1}>
                    <td>{12}</td>
                    <td>
                      {"Enzo"} {"Ramirez"}
                    </td>
                    <td>{this.format(1500000)}GS</td>
                    <td></td>
                    <td></td>
                    <td>{this.format(1500000)}GS</td>
                  </tr>
                }
                <tr>
                  <td>SUBTOTAL</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.format(1500000)}GS</td>
                </tr>
                <tr>
                  <td>TOTAL A PAGAR</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.format(1500000  )}GS</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-md-8"></div>
          <div className="col-md-2">
            <button id="imprimirbtn" >
              Imprimir
            </button>
            <button
              className="btn-primary"
              id="facturarbtn"
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
