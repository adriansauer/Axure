import React, { Component } from "react";
import { connect } from "react-redux";
/**importando acciones */
import { setSectionShow } from "../../Redux/actions";
import "../style.css";
class AsideVenta extends Component {
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
              href="#OrdenVenta"
              onClick={() => this.selectTab(60, 0)}
            >
             Orden de venta
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Clientes"
              onClick={() => this.selectTab(61, 1)}
            >
              Clientes
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              href="#Boton3"
              onClick={() => this.selectTab(62, 2)}
            >
              Facturar
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Boton3"
              onClick={() => this.selectTab(63, 3)}
            >
              Listado de facturas
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

export default connect(mapStateToProps, mapDispatchToProps)(AsideVenta);
