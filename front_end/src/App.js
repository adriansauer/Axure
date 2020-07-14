import React from "react";

/**importando componentes */
import "./Componentes/style.css";
import Body from "./Componentes/Body.js";
import Login from "./Componentes/Login.js";

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      loginVisible: true,
    };
  }
  ocultarLogin() {
    this.setState({ loginVisible: false });
   
  }
  render() {
    return (
      <div className="App">
         
        {this.state.loginVisible ? (
          <Login
            visible={this.state.loginVisible}
            ocultar={this.ocultarLogin.bind(this)}
          />
        ) : (
          <Body />
        )}
      </div>
    );
  }
}

export default App;
