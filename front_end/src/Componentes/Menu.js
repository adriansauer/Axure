import React, { Component } from "react";
import { connect } from "react-redux";
import "./style.css";
import { homeVisible } from "../Redux/actions.js";

class Menu extends Component {
  render() {
    return (
      <div className="Menu btn-group-vertical col-md-2">
        <button
          onClick={() => this.props.homeVisible(false)}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Productos
        </button>
        <button
          onClick={() => this.props.homeVisible(false)}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Venta
        </button>
        <button
          onClick={() => this.props.homeVisible(false)}
          type="button"
          className="btn btn-secondary botonMenu"
        >
          Compra
        </button>
        <button
          onClick={() => this.props.homeVisible(false)}
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
  homeVisible
};
export default connect(mapStateToProps, mapDispatchToProps)(Menu);
