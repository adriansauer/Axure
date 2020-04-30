import React,{Component} from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";



class ProductoDetalles extends Component{
    constructor(props){
        super(props);
        this.state={}
    }

    render(){
        return(
        <Modal isOpen={this.props.visible} centered>
            <ModalHeader>Detalles del Producto</ModalHeader>
            <ModalBody>
              <b> Nombre:</b> {this.props.producto.Name}
              <br />
              <b>Descripcion:</b> {this.props.producto.Description}
              <br />
              <b>Cantidad Minima:</b> {this.props.producto.QuanityMin}
              <br />
              <b>Codigo de Barra:</b> {this.props.producto.Barcode}
              <br />
              <b>Tipo de Producto:</b> {this.props.producto.ProductType.Id}
              <br />
              <b>Costo:</b> {this.props.producto.Cost}
              <br />
              <textarea className="form-control detalles" rows="3"></textarea>
            </ModalBody>
            <ModalFooter>
              <button
                onClick={() => this.props.ocultar()}
              >
                Cerrar
              </button>
            </ModalFooter>
          </Modal>);
    }
}

export default ProductoDetalles;