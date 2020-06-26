import React, { Component } from "react";
import { connect } from "react-redux";
import "./style.css";
import { homeVisible, setModulo,setSectionShow } from "../Redux/actions.js";

class Menu extends Component {
  constructor(props) {
    super(props);
    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false,
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen,
    });
  }

  clickProducto() {
    this.props.homeVisible(false);
    this.props.setModulo(1);
    this.props.setSectionShow(50);
    document.getElementsByClassName("Body")[0].classList.add("producto");
  }
  clickVenta() {
    this.props.homeVisible(false);
    this.props.setModulo(2);
    this.props.setSectionShow(60);

    document.getElementsByClassName("Body")[0].classList.add("venta");
  }
  clickCompra() {
    this.props.homeVisible(false);
    this.props.setModulo(3);
    this.props.setSectionShow(70);

    document.getElementsByClassName("Body")[0].classList.add("compra");
  }
  clickContabilidad() {
    this.props.homeVisible(false);
    this.props.setModulo(4);

    document.getElementsByClassName("Body")[0].classList.add("contabilidad");
  }

  //funcionalidad del menu
  toggleMenu(arg) {
    document.getElementsByClassName("navbar")[0].classList.toggle("inactive");
    document.getElementById("Box--content").classList.toggle("navbar-inactive");
    // if (document.getElementsByClassName('navbar')[0].classList.contains('inactive')) {
    //   setTimeout(() => {
    //     document.getElementById(arg).classList.toggle('show');
    //   }, 350);
    // }else{
    //   document.getElementById(arg).classList.toggle('show');
    // }
  }

  render() {
    return (
      <div id="Menu" className="Menu">
        <nav className="navbar">
          <a className="navbar-brand" href="#home">
            AXure
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="navbarContent"
            onClick={() => this.toggleMenu("navbarContent")}
          >
            <span className="navbar-toggler-icon shadow-effect"></span>
          </button>

          <div className="collapse navbar-collapse show" id="navbarContent">
            <ul className="navbar-nav mx-auto">
              <li className="nav-item active">
                <a
                  className="nav-link"
                  href="#home"
                  onClick={() => this.props.homeVisible(true)}
                >
                  <i className="ico home"></i>
                  <p>Home</p>
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  href="#!"
                  onClick={() => this.clickProducto()}
                >
                  <i className="ico products"></i>
                  <p>Productos</p>
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  href="#!"
                  onClick={() => this.clickVenta()}
                >
                  <i className="ico sells"></i>
                  <p>Ventas</p>
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  href="#!"
                  onClick={() => this.clickCompra()}
                >
                  <i className="ico buys"></i>
                  <p>Compras</p>
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  href="#!"
                  onClick={() => this.props.homeVisible(true)}
                >
                  <i className="ico account"></i>
                  <p>Contabilidad</p>
                </a>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    );
  }
}
const mapStateToProps = (state) => {
  return {
    modulo: state.modulo,
  };
};
const mapDispatchToProps = {
  homeVisible,
  setModulo,
  setSectionShow,
};
export default connect(mapStateToProps, mapDispatchToProps)(Menu);
