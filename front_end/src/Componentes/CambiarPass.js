import React from "react";
import api from "../Axios/Api.js"
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion,{ notify } from "./Notificacion.js";

/**
 * propiedades
 * visible
 * ocultar
 */
class CambiarPass extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      /**Almacenamiento del input text del componente de Login */
      userNametxt: "",
      passwordtxt: "",
      nuevoPass:"",
    };
  }

  
  render() {
    return (
      <div>
<Modal isOpen={this.props.visible} centered> 

        <ModalHeader>Login</ModalHeader>
        <ModalBody>
          <input
            autoComplete="false"
            type="text"
            placeholder="Username"
            required="required"
            value={this.state.userNametxt}
            onChange={(e) => this.setState({ userNametxt: e.target.value })}
          />
          <input
            autoComplete="false"
            type="password"
            placeholder="Password"
            required="required"
            value={this.state.passwordtxt}
            onChange={(e) => this.setState({ passwordtxt: e.target.value })}
          />
          <input
            autoComplete="false"
            type="password"
            placeholder="Nuevo password"
            required="required"
            value={this.state.nuevoPass}
            onChange={(e) => this.setState({ nuevoPass: e.target.value })}
          />
        </ModalBody>
        <ModalFooter>
          
          <button onClick={()=>this.props.ocultar()}>Confirmar</button>
        </ModalFooter>
      </Modal>
      </div>
      
    );
  }
}

export default CambiarPass;
