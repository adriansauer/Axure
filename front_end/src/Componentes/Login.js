import React from "react";
/**librerias de redux */
import { connect } from "react-redux";
/**template */
import { MDBContainer, MDBRow, MDBCol, MDBBtn } from "mdbreact";
/**react router */
import { withRouter } from "react-router";

class Login extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      /**Almacenamiento del input text del componente de Login */
      userNametxt: "",
      passwordtxt: ""
    };
  }

  /**renderizar la pagina de logeo */
  render() {
    console.log(this.props.login(654));
    return (
      <MDBContainer>
        <MDBRow>
          <MDBCol md="4"></MDBCol>
          <MDBCol md="4">
            <form>
              <p className="h4 text-center mb-4">Sign in</p>
              <label htmlFor="defaultFormLoginEmailEx" className="grey-text">
                Su nombre de usuario
              </label>
              <input
                value={this.state.userNametxt}
                onChange={e => this.setState({ userNametxt: e.target.value })}
                id="defaultFormLoginEmailEx"
                className="form-control"
              />
              <br />
              <label htmlFor="defaultFormLoginPasswordEx" className="grey-text">
                Su password
              </label>
              <input
                value={this.state.passwordtxt}
                onChange={e => this.setState({ passwordtxt: e.target.value })}
                type="password"
                id="defaultFormLoginPasswordEx"
                className="form-control"
              />
              <div className="text-center mt-4">
                <MDBBtn color="indigo">Login</MDBBtn>
              </div>
            </form>
          </MDBCol>
          <MDBCol md="4"></MDBCol>
        </MDBRow>
      </MDBContainer>
    );
  }
}

const mapStateToProps = state => ({
  url: state.url
});
const MapDispatchToProps = {};
export default connect(mapStateToProps, MapDispatchToProps)(withRouter(Login));
