import React, { Component } from "react";
import Header from "./Header.js";
import Menu from "./Menu.js";
import Aside from "./Aside.js";
import Section from "./Section.js";
import Home from "./Home.js";
import "./style.css";
import { connect } from "react-redux";

class Body extends Component {
  
  render() {
    
    if (this.props.estado[0]) {
      return (
        <div className="Body">
          <Header />
          <div className="Box row">
            <Menu />
            <Home />
          </div>
        </div>
      );
    } else {
      return (
        <div className="Body">
          <Header />
          <div className="Box row">
            <Menu />
            <Section />
            <Aside />
          </div>
        </div>
      );
    }
  }
}
const mapStateToProps = state => {
  return {
    estado: state.homeVisible,
    modulo:state.modulo
  };
};
const mapDispatchToProps = {};
export default connect(mapStateToProps, mapDispatchToProps)(Body);
