import React, { Component } from "react";
import Header from "./Header.js";
import Menu from "./Menu.js";
import Aside from "./Aside.js";
import Section from "./Section.js";
import "./style.css";
import { connect } from "react-redux";

class Body extends Component {
  constructor(props){
    super(props);
    this.state={

    }
  }
  

  render() {
    
   
   
      return (
        <div className="Body">
         
          <Header />
          <div className="Body--Box">
            <Menu />
            <div id="Box--content" className="Box--content navbar-inactive">
              <Aside />
              <Section />
            </div>   
          </div>
        </div>
      );
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
