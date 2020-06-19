import React, { Component } from "react";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import api from "../../../Axios/Api.js";
import Notificacion, { notify } from "../../Notificacion";

class Factura extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }
  printDiv(nombreDiv) {
    var contenido = document.getElementById(nombreDiv).innerHTML;
    var contenidoOriginal = document.body.innerHTML;

    document.body.innerHTML = contenido;

    window.print();

    document.body.innerHTML = contenidoOriginal;
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
          ProductId: p.Id,
          Quantity: p.QuantitySale,
        };
      }),
    };
console.log(factura);
    try {
      const request = await api.factura.create(factura);
      console.log(request);
      if (request.status === 200) {
        notify("Factura creada exitosamente", "success");
      } else {
        notify("Error al intentar crear la factura", "danger");
      }
    } catch (error) {
      notify("Error al intentar crear la factura", "danger");
    }
  }

  render() {
    return (
      <div className="Factura">
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
            <label>
              NOMBRE O RAZON SOCIAL:{this.props.factura.ClientDTO.Name}
            </label>
          </div>
          <div className="col-md-6">
            <label>CONDICION DE VENTA:{this.props.factura.SaleCondition}</label>
          </div>
          <div className="col-md-6">
            <label>DIRECCION:{this.props.factura.ClientDTO.Address}</label>
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
                    <td>{i.UnitPrice}</td>
                    <td></td>
                    <td></td>
                    <td>{i.Tax}</td>
                  </tr>
                ))}
                <tr>
                  <td>SUBTOTAL</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.props.factura.TaxTotal}</td>
                </tr>
                <tr>
                  <td>TOTAL A PAGAR</td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td>{this.props.factura.Total}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-md-8"></div>
          <div className="col-md-2">
            <button onClick={() => this.printDiv("imprimir")}>Imprimir</button>
            <button onClick={() => this.facturar()}>Facturar</button>
          </div>
        </div>
      </div>
    );
  }
}
export default Factura;
