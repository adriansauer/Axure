import React, { Component } from "react";
import { connect } from "react-redux";
/**importando acciones */
import { setSectionShow } from "../../Redux/actions";
import "../style.css";
class AsideCompras extends Component {
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
              href="#Compra"
              onClick={() => this.selectTab(76, 0)}
            >
             Orden de Compra
            </a>
          </li>
          
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Proveedor"
              onClick={() => this.selectTab(72, 1)}

            >
              Proveedores
            </a>
          </li>
          <li className="nav-item">
            <a

              className="nav-link "
              href="#Factura"
              onClick={() => this.selectTab(73, 2)}

            >
              Facturacion
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

export default connect(mapStateToProps, mapDispatchToProps)(AsideCompras);