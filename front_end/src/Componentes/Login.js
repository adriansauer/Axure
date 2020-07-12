import React from "react";
import api from "../Axios/Api.js"
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion,{ notify } from "./Notificacion.js";
import CambiarPass from "./CambiarPass.js";
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
      cambiarPassVisible:false,
    };
  }

  async solicitar(){
    try {
      const token=await api.token.get({
        username:this.state.userNametxt,
        password:this.state.passwordtxt,
        grant_type:"password"

      });
       notify("Logeado","success");
        this.props.ocultar();
 
    } catch (error) {
      notify("Error de conexion","danger");
    }
    
  }
  ocultar(){
    this.setState({cambiarPassVisible:false});
  }
  render() {
    return (
      <div>
        <Notificacion/>
<Modal isOpen={this.props.visible} centered> 

        <ModalHeader>Login</ModalHeader>
        <ModalBody>
          <CambiarPass visible={this.state.cambiarPassVisible} ocultar={this.ocultar.bind(this)}/>
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
        </ModalBody>
        <ModalFooter>
          <button onClick={()=>this.setState({cambiarPassVisible:true})}>Cambiar password</button>
          <button onClick={() => this.solicitar()}>Login</button>
        </ModalFooter>
      </Modal>
      </div>
      
    );
  }
}

export default Login;
