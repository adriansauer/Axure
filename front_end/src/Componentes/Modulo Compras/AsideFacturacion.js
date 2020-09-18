import React, { Component } from "react";
import { connect } from "react-redux";
/**importando acciones */
import { setSectionShow } from "../../Redux/actions";
import "../style.css";
class AsideFacturacion extends Component {
  selectTab(args, trackNumber) {
    let selector = args;
    var aux = document.getElementById("AsideA").querySelectorAll(".nav-link");
    for (let index = 0; index < aux.length; index++) {
      const element = aux[index];
      element.classList.remove("active");
    }
    aux.item(trackNumber).classList.add("active");
    this.props.setSectionShow(selector);
  }

  render() {
    return (
      <div id="AsideA" className="Aside">
        <ul className="nav nav-tabs">
          
          <li className="nav-item">
            <a

              className="nav-link "
              href="#Facturas"
              onClick={() => this.selectTab(74, 0)}

            >
              Facturar
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link "
              href="#Facturas"
              onClick={() => this.selectTab(75, 1)}

            >
              Facturas
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

export default connect(mapStateToProps, mapDispatchToProps)(AsideFacturacion);