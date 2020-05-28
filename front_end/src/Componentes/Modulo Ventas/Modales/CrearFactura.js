import React, { Component } from "reacrt";
import { Modal, ModalFooter, ModalBody, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
/**
 * ocultar()
 * visible
 * productos{ProductId,Quantity}
 * cliente
 * orden
 */
class CrearFactura extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div>
        <Notificacion />

        <Modal isOpen={this.props.visible} centered>
          <ModalHeader>Factura</ModalHeader>
          <ModalBody></ModalBody>
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

export default CrearFactura;
