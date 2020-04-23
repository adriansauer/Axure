import React, { Component } from "react";
import { connect } from "react-redux";
/**importando acciones */
import { setSectionShow } from "../../Redux/actions";
import "../style.css";
class AsideProducto extends Component {
  render() {
    return (
      <div id="Aside" className="Aside">
        <ul className="nav nav-tabs">
          <li className="nav-item">
            <a className="nav-link active" href="#" onClick={() => this.props.setSectionShow(50)}>Stock</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#" onClick={() => this.props.setSectionShow(51)}>Agregar Producto</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#" onClick={() => this.props.setSectionShow(52)}>Orden de Produccion</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#" onClick={() => this.props.setSectionShow(53)}>Ordenes de Produccion</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#" onClick={() => this.props.setSectionShow(54)}>Productos de Baja</a>
          </li>
        </ul>
        
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {
    codigo: state.sectionShow
  };
};
const mapDispatchToProps = {
  setSectionShow
};

export default connect(mapStateToProps, mapDispatchToProps)(AsideProducto);
