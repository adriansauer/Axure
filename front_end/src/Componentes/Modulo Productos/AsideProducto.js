import React, { Component } from "react";
import { connect } from "react-redux";
/**importando acciones */
import { setSectionShow } from "../../Redux/actions";
import "../style.css";
class AsideProducto extends Component {
  selectTab(args, trackNumber) {
    let selector = args;
    var aux = document.getElementById("Aside").querySelectorAll(".nav-link");
    for (let index = 0; index < aux.length; index++) {
      const element = aux[index];
      element.classList.remove("active");
    }
    aux.item(trackNumber).classList.add("active");
    this.props.setSectionShow(selector);
  }

  render() {
    return (
      <div id="Aside" className="Aside">
        <ul className="nav nav-tabs">
          <li className="nav-item">
            <a
              className="nav-link active"
              href="#Stock"
              onClick={() => this.selectTab(50, 0)}
            >
              Stock
            </a>
          </li>
    
          <li className="nav-item">
            <a
              className="nav-link"
              href="#OrdenProduccion"
              onClick={() => this.selectTab(52, 1)}
            >
              Orden de Produccion
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              href="#Ingreso_Egreso"
              onClick={() => this.selectTab(55, 2)}
            >
              Ingreso/Egreso
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              href="#OrdenesProduccion"
              onClick={() => this.selectTab(53, 3)}
            >
              Ordenes de Produccion
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              href="#Movimientos"
              onClick={() => this.selectTab(54, 4)}
            >
              Movimientos
            </a>
          </li>
        </ul>
      </div>
    );
  }
}
const mapStateToProps = (state) => {
  return {
    codigo: state.sectionShow,
  };
};
const mapDispatchToProps = {
  setSectionShow,
};

export default connect(mapStateToProps, mapDispatchToProps)(AsideProducto);
