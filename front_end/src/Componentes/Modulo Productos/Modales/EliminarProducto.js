import React, { Component } from "react";
import { ModalFooter, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";
class EliminarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }
  async eliminarProducto() {
   
    await api.productos.delete(this.props.producto.Id);
    /**actualizo los datos */
    this.props.actualizar();
    this.props.ocultar();
  }
  render() {
    
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>
          Desea eliminar el producto {this.props.producto.Name}-
          {this.props.producto.Description}?
        </ModalHeader>
        <ModalFooter>
          <button onClick={() => this.eliminarProducto()}>Si</button>
          <button
            onClick={() => this.props.ocultar()}
          >
            No
          </button>
        </ModalFooter>
      </Modal>
    );
  }
}

export default EliminarProducto;
