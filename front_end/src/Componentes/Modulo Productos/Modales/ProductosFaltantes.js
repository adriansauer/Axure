import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";

class ProductosFaltantes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: null,
    };
  }
  /**
   * propiedades: lista
   *              ocultar
   *              visible
   */
  async componentWillReceiveProps() {
    const request = await api.productos.get();
    this.setState({ productos: request.data });
  }

  render() {
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>
            Faltan componentes para producir los siguientes productos.    
        </ModalHeader>
        <ModalBody>
          <div className="row">
            {this.props.lista !== undefined && this.props.lista !== null ? (
              <p>{this.props.lista.Observation}</p>
            ) : null}
          </div>
          <div className="row">
            <div className="StockBody">
              <table className="table table-hover table">
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripcion</th>
                    <th scope="col">Codigo de barra</th>
                   
                  </tr>
                </thead>
                {this.props.lista !== null ? (
                  <tbody className="tableBody">
                    {(this.props.lista!==undefined && this.props.lista!==null)? this.props.lista.map((p) => (
                      <tr key={p}>
                        {this.state.productos
                          .filter((e) => e.Id === p)
                          .map((r) => (
                            <td key={r.Id}>{r.Name}</td>
                          ))}
                        {this.state.productos
                          .filter((e) => e.Id === p)
                          .map((r) => (
                            <td key={r.Id}>{r.Description}</td>
                          ))}
                        {this.state.productos
                          .filter((e) => e.Id === p)
                          .map((r) => (
                            <td key={r.Id}>{r.Barcode}</td>
                          ))}
                       
                      </tr>
                    )):null}
                  </tbody>
                ) : null}
              </table>
            </div>
          </div>
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.props.ocultar()}>Cerrar</button>
        </ModalFooter>
      </Modal>
    );
  }
}
export default ProductosFaltantes;