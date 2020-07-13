import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";

class FacturaDetalles extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: []
    };
  }
  
  async componentWillReceiveProps() {
    if (this.props.factura.Id !== ""){
      const request = await api.factura_compra.getDetalles(this.props.factura.Id);
      this.setState({ 
        productos: request.data
      });
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

  render() {
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>Detalles de la Factura </ModalHeader>
        <ModalBody>
            <div>
            <div className="StockBody">
              <table className="table table-hover table">
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Producto</th>
                    <th scope="col">Cantidad</th>
                    <th scope="col">IVA</th>
                    <th scope="col">Total</th>
                  </tr>
                </thead>

                <tbody className="tableBody">
                  {
                    this.state.productos.map((p) => (
                      <tr key = {p.Id}>
                        <td>{p.ProductName}</td>
                        <td>{p.Quantity}</td>
                        <td>{p.TaxTotal}</td>
                        <td>{p.Total}</td>
                      </tr>
                    ))
                  }
                </tbody>
              </table>
            </div>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={() => this.props.ocultar()}>Cerrar</button>
        </ModalFooter>
      </Modal>
    );
  }
}

export default FacturaDetalles;
