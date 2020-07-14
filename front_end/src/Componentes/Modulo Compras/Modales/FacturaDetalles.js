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
  
  async UNSAFE_componentWillReceiveProps() {
      const request = await api.productos.get();
      this.setState({ 
        productos: request.data
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
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>Detalles de la Factura </ModalHeader>
        <ModalBody>
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

                {this.props.factura !== null ? (
                <tbody className="tableBody">
                    {this.props.factura.ListItem.map((p) => (
                      <tr key = {p.Id}>
                        {this.state.productos
                            .filter((e) => e.Id === p.ProductId)
                            .map((r) => (
                            <td key={r.Id}>{p.ProductName} {r.Description}</td>
                            ))}
                        <td>{p.Quantity}</td>
                        <td>{this.formato("es-PY","PYG",p.TaxTotal)}</td>
                        <td>{this.formato("es-PY","PYG",p.Total)}</td>
                      </tr>
                    ))}
                </tbody>
                ):null}
              </table>
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
