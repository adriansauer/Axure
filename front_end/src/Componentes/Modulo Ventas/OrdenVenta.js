import React, { Component } from "react";
import "../Modulo Productos/styleMProductos.css";
import TablaProductoSelector from "../Modulo Productos/TablaProductoSelector";
import AgregarCliente from "./Modales/AgregarCliente.js";
class OrdenVenta extends Component {
  constructor(props) {
    super(props);
    this.state = {
      agregarClienteVisible: false,
      productosSeleccionados: [],
      buscador: "",
    };
  }
  async componentDidMount() {
    const f = new Date();

    let mes = f.getMonth() + 1; //obteniendo mes
    let dia = f.getDate(); //obteniendo dia
    let ano = f.getFullYear(); //obteniendo año
    if (dia < 10) dia = "0" + dia; //agrega cero si el menor de 10
    if (mes < 10) mes = "0" + mes; //agrega cero si el menor de 10
    document.getElementById("fecha").value = ano + "-" + mes + "-" + dia;
  }
  sacarProducto(id) {}
  ocultarModales() {
    this.setState({ agregarClienteVisible: false });
  }
  render() {
    return (
      <div className="Container">
        <AgregarCliente
          ocultar={this.ocultarModales.bind(this)}
          visible={this.state.agregarClienteVisible}
        />
        <div className="row">
          <div className="col-md-4">
            <input
              autocomplete="off"
              type="text"
              id="cliente"
              className="form-control"
              placeholder="Cliente"
            />
          </div>
          <div className="col-md-2">
            <button className="btn btn-primary" onClick={()=>this.setState({agregarClienteVisible:true})}>Agregar Cliente</button>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <input
                type="date"
                name="date"
                id="fecha"
                max="3000-12-31"
                min="1000-01-01"
                className="form-control"
              />
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <input
              autocomplete="off"
              type="text"
              id="encargado"
              className="form-control"
              placeholder="Encargado"
            />
          </div>
        </div>

        <div className="row">
          <div className="col">
            <TablaProductoSelector
              productos={this.state.productosSeleccionados}
              delete={this.sacarProducto.bind(this)}
            />
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <input
              className="form-control form-control-sm  buscador"
              type="text"
              id="id1"
              autocomplete="off"
              placeholder="Añadir producto"
              onChange={(e) => {
                this.setState({ buscador: e.target.value });
              }}
              value={this.state.buscador}
            />
          </div>

          <div className="col-md-4"></div>

          <div className="col-md-3">
            <button className="btn btn-primary" style={{ marginTop: 20 }}>
              Guardar
            </button>
          </div>
        </div>
      </div>
    );
  }
}

export default OrdenVenta;
