import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
import api from ".././../../Axios/Api.js";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 * orden
 */

class FacturarModal extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: [],
    };
  }
  async componentDidMount() {
    try {
      const productos = await api.productos.getProductosDeVenta();
      this.setState({ productos: productos.data });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  facturar() {}
  render() {
    return (
      <div>
        <Notificacion />

        <Modal isOpen={this.props.visible} centered>
          <ModalHeader>Facturar</ModalHeader>
          <ModalBody>
            <div className="row"></div>
            <div className="row">
              <table
                className="table table-hover table"
                style={{ marginTop: "3%" }}
              >
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Producto</th>
                    <th scope="col">Cantidad total</th>
                    <th scope="col">Cantidad pendiente</th>      
                    <th scope="col">Cantidad a facturar</th>               
                  </tr>
                </thead>
                <tbody className="tableBody">
                  {this.props.orden !== null
                    ? this.props.orden.ListDetails.map((p) => (
                        <tr key={p.Id}>
                          {this.state.productos
                            .filter((e) => e.Id === p.ProductId)
                            .map((e) => (
                              <td>
                                {e.Name} {e.Description}
                              </td>
                            ))}
                          <td>{p.Quantity}</td>
                          <td>{p.Quantity - p.QuantityPending}</td>
                          <td>
                            <input
                              type="text"
                              className="form-control"
                              defaultValue="0"
                              placeholder="Cantidad a facturar"
                            />
                          </td>
                        </tr>
                      ))
                    : null}
                </tbody>
              </table>
            </div>
          </ModalBody>
          <ModalFooter>
            <button onClick={() => this.facturar()}>Facturar</button>
            <button className="exit" onClick={() => this.props.ocultar()}>
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}
export default FacturarModal;
