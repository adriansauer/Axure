import React from "react";

/**template */
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";

/**
 * propiedades
 * visible
 * ocultar
 */
class Login extends React.Component {
  constructor(props) {
    super(props);
  
    this.state = {
      /**Almacenamiento del input text del componente de Login */
      userNametxt: "",
      passwordtxt: "",
    };
  }
  
  /**renderizar la pagina de logeo */
  render() {
    return (
      <Modal isOpen={this.props.visible} centered>
        <ModalHeader>Login</ModalHeader>
        <ModalBody>Logeate</ModalBody>
        <ModalFooter>
          <button onClick={()=>this.props.ocultar()}>Login</button>
        </ModalFooter>
      </Modal>
    );
  }
}

export default Login;
