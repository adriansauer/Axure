import React from 'react';
/**librerias de redux */
import {connect} from 'react-redux';
/**Librerias de axios */
import axios from 'axios';
import qs from "qs";
/**template */
import { MDBContainer, MDBRow, MDBCol, MDBBtn } from 'mdbreact';
/**react router */
import {withRouter} from 'react-router';

class Login extends React.Component {
  constructor(props){
    super(props);
    this.state={
      /**Almacenamiento del input text del componente de Login */
      userNametxt:'',
      passwordtxt:''
    }
  }
  /**esta funcion se llama cuando se da click en boton login */
logear(){
  const data = qs.stringify({ username: this.state.userNametxt, password: this.state.passwordtxt, grant_type: 'password' });
axios.post('http://localhost:53049/token', data).then(t=>{
  console.log(t);
  this.props.history.push('/home');
})
  
}
/**renderizar la pagina de logeo */
  render(){
     
return (
<MDBContainer>
  <MDBRow>
  <MDBCol md="4">
  </MDBCol>
    <MDBCol md="4">
      <form>
        <p className="h4 text-center mb-4">Sign in</p>
        <label htmlFor="defaultFormLoginEmailEx" className="grey-text">
          Su nombre de usuario
        </label>
        <input value={this.state.userNametxt} onChange={e=>this.setState({userNametxt:e.target.value})}  id="defaultFormLoginEmailEx" className="form-control" />
        <br />
        <label htmlFor="defaultFormLoginPasswordEx" className="grey-text">
          Su password
        </label>
        <input value={this.state.passwordtxt} onChange={e=>this.setState({passwordtxt:e.target.value})} type="password" id="defaultFormLoginPasswordEx" className="form-control" />
        <div className="text-center mt-4">
          <MDBBtn onClick={()=>this.logear()} color="indigo" >Login</MDBBtn><MDBBtn color="indigo" onClick={()=>this.props.history.push('/registro')}>Registrarse</MDBBtn>
        </div>
      </form>
    </MDBCol>
    <MDBCol md="4">
  </MDBCol>
  </MDBRow>
</MDBContainer>
);
  }
}

const mapStateToProps=state=>({
    url:state.url
})
const MapDispatchToProps=dispatch=>({
  /**Action que se utiliza una vez el usuario se haya logeado para guardar sus datos */
    login(user){
      dispatch({
        type:'LOGIN',
        user
      })
    }
})
export default connect(mapStateToProps,MapDispatchToProps)(withRouter(Login))