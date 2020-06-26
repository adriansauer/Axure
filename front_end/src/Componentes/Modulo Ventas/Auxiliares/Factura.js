import React, { Component } from "react";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";

class Factura extends Component {
  constructor(props) {
    super(props);
    this.state = {};
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
  async facturar() {
    const factura = {
      OrderSaleId: this.props.orden.Id,
      EmployeeId: this.props.factura.EmployeeDTO.Id,
      ClientId: this.props.factura.ClientDTO.Id,
      SaleCondition: this.props.factura.SaleCondition,
      InvoiceNumber: this.props.factura.InvoiceNumber,
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
    if (this.props.factura.ValidationCode === 0) {
      try {
        const request = await api.factura.create(factura);
        if (request.status === 200) {
        //  document.getElementById("facturarbtn").style.display = "none";
         // document.getElementById("imprimirbtn").style.display = "hidden";
          notify("Factura creada exitosamente", "success");
        } else {
          notify("Error al intentar crear la factura", "danger");
        }
      } catch (error) {
        notify("Error al intentar crear la factura", "danger");
      }
    } else if (this.props.factura.ValidationCode === 1) {
      notify("No hay productos suficientes en stock", "warning");
    } else if (this.props.factura.ValidationCode === 2) {
      notify("El cliente no cuenta con credito disponible", "warning");
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
        <div className="row" id="imprimir">
          <div className="col-md-6">
            <label style={{ marginLeft: "100px" }}>
              NOMBRE O RAZON SOCIAL:{this.props.factura.ClientDTO.Name}
            </label>
          </div>
          <div className="col-md-6">
            <label>CONDICION DE VENTA:{this.props.factura.SaleCondition}</label>
          </div>
          <div className="col-md-6">
            <label style={{ marginLeft: "100px" }}>
              DIRECCION:{this.props.factura.ClientDTO.Address}
            </label>
          </div>
          <div className="col-md-6">
            <label>RUC:{this.props.factura.ClientDTO.RUC}</label>
          </div>
          <div className="col-md-12">
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
                    <td>{this.format(i.UnitPrice)}GS</td>
                    <td></td>
                    <td></td>
                    <td>{this.format(i.Total)}GS</td>
                  </tr>
                ))}
                <tr>
                  <td>SUBTOTAL</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.format(this.props.factura.TaxTotal)}GS</td>
                </tr>
                <tr>
                  <td>TOTAL A PAGAR</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.format(this.props.factura.Total)}GS</td>
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
              name="facturarbtn"
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
