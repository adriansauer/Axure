import React,{Component} from 'react';
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 */

class AgregarCliente extends Component{
    constructor(props){
        super(props);
        this.state={}
    }

    render(){
        return(
            <Modal isOpen={this.props.visible} centered>
            <ModalHeader>Agregar cliente</ModalHeader>
            <ModalBody>
              <div className="row">
              <div className="col-md-7">
                {/**NOMBRE DEL CLIENTE*/}
                <input
                autocomplete="off"
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="Nombre"
                  maxLength="100"
                />
              </div>
              <div className="col-md-7">
                {/**DIRECCION DEL CLIENTE*/}
                <input
                autocomplete="off"
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="Direccion"
                  maxLength="200"
                />
              </div>
              <div className="col-md-7">
                {/**RUC DEL CLIENTE*/}
                <input
                 autocomplete="off"
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="RUC"
                  maxLength="20"
                />
              </div>
              <div className="col-md-7">
                {/**CREDITO MAXIMO DEL CLIENTE*/}
                <input
                autocomplete="off"
                  type="text"
                  id="nombre"
                  className="form-control"
                  placeholder="Credito maximo"
                />
              </div>
              </div>
            </ModalBody>
            <ModalFooter>
              <button >
                Guardar
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
export default AgregarCliente;