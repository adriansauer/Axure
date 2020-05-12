import React,{Component} from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import api from "../../../Axios/Api.js";
class EditarProducto extends Component{
    constructor(props){
        super(props);
        this.state={}
    }
/**Edito el un producto y actualizo la tabla */
async editarProducto() {
   const request= await api.productos.edit(this.props.producto.Id, {
      Name: document.getElementById("nombre").value,
      Description: document.getElementById("descripcion").value,
      Cost: document.getElementById("costo").value,
      QuantityMin: document.getElementById("cantidadMin").value,
      Barcode: document.getElementById("codigoBarra").value,
      ProductTypeId: this.props.producto.ProductType.Id,
    });
    
    this.props.actualizar();
    this.props.ocultar();
  }
    render(){
        return(
<Modal isOpen={this.props.visible} centered>
        <ModalHeader>Editar Producto</ModalHeader>
        <ModalBody>
          <form>
            <div className="form-row">
              <div className="col-md-6">
                {/**NOMBRE DEL PRODUCTO*/}
                <input
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="Nombre del Producto"
                  defaultValue={this.props.producto.Name}
                />
              </div>
              <div className="col-md-6">
                {/**DESCRIPCION DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  id="descripcion"
                  placeholder="Descripcion del producto"
                  defaultValue={this.props.producto.Description}
                />
              </div>
              <div className="col-md-6">
                {/**COSTO DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  id="costo"
                  placeholder="Costo"
                  defaultValue={this.props.producto.Cost}
                />
              </div>
              <div className="col-md-6">
                {/**CANTIDAD MINIMA DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  id="cantidadMin"
                  placeholder="Cantidad Minima"
                  defaultValue={this.props.producto.QuantityMin}
                />
              </div>
              <div className="col-md-6">
                {/**CODIGO DE BARRA DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  id="codigoBarra"
                  placeholder="Codigo de barra"
                  defaultValue={this.props.producto.Barcode}
                />
              </div>
              <div className="col-md-12"></div>
            </div>
          </form>
        </ModalBody>
        <ModalFooter>
          <button className="primary" onClick={() => this.editarProducto()}>
            Agregar Cambios
          </button>
          <button
            className="exit"
            onClick={() => this.props.ocultar()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

        );
    }
}

export default EditarProducto;