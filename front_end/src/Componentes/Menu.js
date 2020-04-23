import React, { Component, useState } from "react";
import { connect } from "react-redux";
import "./style.css";
import { homeVisible ,setModuloSuccess} from "../Redux/actions.js";
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink} from "reactstrap";


class Menu extends Component {

  constructor(props){
    super(props);
    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen:false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  };

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
    const isOpen = this.state.isOpen;
    return (
      <div id="Menu" className="Menu">

        <nav className="navbar active">
          <a className="navbar-brand" href="#home">AXure</a>
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="navbarContent">
            <span className="navbar-toggler-icon shadow-effect"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarContent">
            <ul className="navbar-nav mx-auto">
              <li className="nav-item active">
                <a className="nav-link" href="#home" onClick={() => this.props.homeVisible(true)}>
                  <i></i>
                  Home
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.clickProducto()}>
                  <i></i>
                  Productos
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i></i>
                  Ventas
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i></i>
                  Compras
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i></i>
                  Contabilidad
                </a>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {};
};
const mapDispatchToProps = {
  homeVisible,
  setModuloSuccess,
};
export default connect(mapStateToProps, mapDispatchToProps)(Menu);
