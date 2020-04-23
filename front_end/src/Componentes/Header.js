import React, { Component, useState } from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import "./style.css";
import HomeIcon from "@material-ui/icons/Home";
import { connect } from "react-redux";
import { homeVisible } from "../Redux/actions.js";
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink} from "reactstrap";

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
