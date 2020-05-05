import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";
import "../styleMProductos.css";

class ProductoDetalles extends Component {
  constructor(props) {
    super(props);
    this.state = {
      componentes: [],
      productos: null,
    };
  }
  async componentWillReceiveProps() {
    if (this.props.producto.Id !== "") {
      const request = await api.productos.getComponents(this.props.producto.Id);
      const request2 = await api.productos.get();
      this.setState({ componentes: request.data, productos: request2.data });
    }
  }
  render() {
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>Detalles del Producto</ModalHeader>
        <ModalBody>
          <b> Nombre:</b> {this.props.producto.Name}
          <br />
          <b>Descripcion:</b> {this.props.producto.Description}
          <br />
          <b>Cantidad Minima:</b> {this.props.producto.QuantityMin}
          <br />
          <b>Codigo de Barra:</b> {this.props.producto.Barcode}
          <br />
          <b>Costo:</b> {this.props.producto.Cost}
          <br />
            {this.state.componentes.lenght!==[]?
            <div>
            <b>Componentes</b>
            <div className="StockBody">
              <table className="table table-hover table">
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripcion</th>
                    <th scope="col">Codigo de barra</th>
                    <th scope="col">Cantidad</th>
                  </tr>
                </thead>

                <tbody className="tableBody">
                { this.state.componentes.map((p) => (
                        <tr key={p.Id}>
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductComponentId)
                            .map((r) => (
                              <td key={r.Id}>{r.Name}</td>
                            ))}
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductComponentId)
                            .map((r) => (
                              <td key={r.Id}>{r.Description}</td>
                            ))}
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductComponentId)
                            .map((r) => (
                              <td key={r.Id}>{r.Barcode}</td>
                            ))}
                          <td>{p.Quantity}</td>
                        </tr>
                      ))
                   }
                </tbody>
              </table>
            </div>
          </div>
          :
          null
          }
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.props.ocultar()}>Cerrar</button>
        </ModalFooter>
      </Modal>
    );
  }
}

export default ProductoDetalles;
