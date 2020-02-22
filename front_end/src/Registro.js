import React,{Component} from 'react';

/**template */
import { MDBContainer, MDBRow, MDBCol, MDBBtn } from 'mdbreact';
/**react router */
import {withRouter} from 'react-router';



class Registro extends Component{
    constructor(props){
        super(props);
        this.state={
            passwordtxt:'',
            passwordtxt2:'',
            userNametxt:''
        }
    }
registrarse(){
    this.props.history.push('/login');
}
    render(){
        return(
            <div>
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

        <label htmlFor="defaultFormLoginPasswordEx" className="grey-text">
          Confirme su password
        </label>
        <input value={this.state.passwordtxt2} onChange={e=>this.setState({passwordtxt2:e.target.value})} type="password" id="defaultFormLoginPasswordEx2" className="form-control" />
        <div className="text-center mt-4">
          <MDBBtn color="indigo" onClick={()=>this.registrarse()} type="submit">Registrarse</MDBBtn>
        </div>
      </form>
    </MDBCol>
    <MDBCol md="4">
  </MDBCol>
  </MDBRow>
</MDBContainer>
            </div>
        );
    }
}
export default withRouter(Registro);