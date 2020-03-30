import React, { Component } from "react";
import { connect } from "react-redux";
import "./style.css";
import { homeVisible ,setModuloSuccess} from "../Redux/actions.js";

class Menu extends Component {
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
      <div className="Menu btn-group-vertical col-md-2">
           
        <button
          onClick={() => this.clickProducto()}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Productos
        </button>
        <button
          onClick={() => this.clickVenta()}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Venta
        </button>
        <button
          onClick={() => this.clickCompra()}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Compra
        </button>
        <button
          onClick={() => this.clickContabilidad()}
          type="button"
          className="btn btn-secondary botonMenu1"
        >
          Contabilidad
        </button>
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
