import React, { Component } from "react";
import "./style.css";
import { connect } from "react-redux";
import { homeVisible } from "../Redux/actions.js";

class Header extends Component {
  constructor(props) {
    super(props);
    this.state = {
    };
  }

// funciones para cargar modulos
clickProducto(){
  this.props.homeVisible(false);
  document.getElementsByClassName("Body")[0].classList.add("producto");
}
clickVenta(){
  this.props.homeVisible(false);
  document.getElementsByClassName("Body")[0].classList.add("venta");
}
clickCompra(){
  this.props.homeVisible(false);
  document.getElementsByClassName("Body")[0].classList.add("compra");
}
clickContabilidad(){
  this.props.homeVisible(false);
  document.getElementsByClassName("Body")[0].classList.add("contabilidad");
}

  render() {
    
    return (
      <div id="Header" className="Header">
        
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {};
};
const mapDispatchToProps = {
  homeVisible
};
export default connect(mapStateToProps, mapDispatchToProps)(Header);
