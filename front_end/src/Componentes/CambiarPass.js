import React from "react";
import api from "../Axios/Api.js"
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion,{ notify } from "./Notificacion.js";
import "../login.css"
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
      nuevoPass:"",
    };
  }
async enviar(){
  try {
    const request=await api.password.edit({UserName:this.state.userNametxt,Password:this.state.nuevoPass});
    this.props.ocultar();
  } catch (error) {
    
  }
}
  
  render() {
    return (
      <Modal isOpen={this.props.visible} centered> 

      <div className="wrapper fadeInDown">
      <div id="formContent">
        <form>
          <input
            type="text"
            id="login"
            className="fadeIn second"
            name="login"
            placeholder="login"
            value={this.state.userNametxt}
            onChange={(e) => this.setState({ userNametxt: e.target.value })}
          />
          <input
            type="password"
            id="password"
            className="fadeIn third"
            name="login"
            placeholder="nuevo password"
            value={this.state.nuevoPass}
            onChange={(e) => this.setState({ nuevoPass: e.target.value })}
          />
          <input type="submit" onClick={()=>this.enviar()} className="fadeIn fourth" value="Cambiar" />
          <input type="submit" onClick={()=>this.props.ocultar()} className="fadeIn fourth" value="Cancelar" />
        </form>

        
      </div>
    </div>   
      </Modal>
      
    );
  }
}

export default CambiarPass;
