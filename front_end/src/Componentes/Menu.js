import React, { Component} from "react";
import { connect } from "react-redux";
import "./style.css";
import { homeVisible ,setModuloSuccess} from "../Redux/actions.js";


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

  //funcionalidad del menu
  toggleMenu(arg){
    document.getElementsByClassName('navbar')[0].classList.toggle('active');
    document.getElementById('Box--content').classList.toggle('navbar-active')
    if (document.getElementsByClassName('navbar')[0].classList.contains('active')) {
      setTimeout(() => {
        document.getElementById(arg).classList.toggle('show');
      }, 350);
    }else{
      document.getElementById(arg).classList.toggle('show');
    }
  }

  render() {
    return (
      <div id="Menu" className="Menu">

        <nav className="navbar">
          <a className="navbar-brand" href="#home">AXure</a>
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="navbarContent" onClick={() => this.toggleMenu('navbarContent')}>
            <span className="navbar-toggler-icon shadow-effect"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarContent">
            <ul className="navbar-nav mx-auto">
              <li className="nav-item active">
                <a className="nav-link" href="#home" onClick={() => this.props.homeVisible(true)}>
                  <i className="ico home"></i>
                  Home
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.clickProducto()}>
                  <i className="ico products"></i>
                  Productos
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i className="ico sells"></i>
                  Ventas
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i className="ico buys"></i>
                  Compras
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#!" onClick={() => this.props.homeVisible(true)}>
                  <i className="ico account"></i>
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
