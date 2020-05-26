import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";

class ordenDetalles extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: null,
    };
  }
 
  async UNSAFE_componentWillReceiveProps() {
    
      const request = await api.productos.get();
      this.setState({ productos: request.data });
    
  }

  render() {
   
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>Detalles de la orden</ModalHeader>
        <ModalBody>
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
              {/**Mapeo el arreglo de productos que nos proporciona la api y muestro los productos en la tabla */}
              {this.props.orden !== null ? (
                <tbody className="tableBody">
                  {this.props.orden.ListDetails.map((p) => (
                  <tr key={p.Id}>
                    {this.state.productos
                            .filter((e) => e.Id === p.ProductId)
                            .map((r) => (
                              <td key={r.Id}>{r.Name}</td>
                            ))}
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductId)
                            .map((r) => (
                              <td key={r.Id}>{r.Description}</td>
                            ))}
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductId)
                            .map((r) => (
                              <td key={r.Id}>{r.Barcode}</td>
                            ))}
                    <td>{p.Quantity}</td>
                  </tr>
                  ))}
                </tbody>
              ) : null}
            </table>
          </div>
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.props.ocultar()}>Cerrar</button>
        </ModalFooter>
      </Modal>
    );
  }
}
export default ordenDetalles;
