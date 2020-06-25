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
              onClick={() => this.selectTab(70, 0)}
            >
             Orden de Compra
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Boton2"
            >
              Boton 2
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              href="#Boton3"
            >
              Boton 3
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Boton3"
            >
              Boton 4
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Boton5"
            >
              Boton 5
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