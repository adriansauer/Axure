import React, { Component } from "react";
import { connect } from "react-redux";
import {getProductos,getEmpleados} from "../../Redux/actions.js";
import './styleMProductos.css'
import TablaProductoSelector from "./TablaProductoSelector.js";

class DarDeBaja extends Component {
  constructor(props) {
    super(props);
    this.state = {
        productos: this.props.productos,
        buscador: "",
        productosSeleccionados: [],
        observacion: "",
        encargado: {},
        encargadoNombre: "",
        empleados: [],
        empleadoElegido: false,
        

    };
  }
  async componentDidMount() {
    await this.props.getEmpleados();
    await this.props.getProductos();
    const f = new Date();

    let mes = f.getMonth() + 1; //obteniendo mes
    let dia = f.getDate(); //obteniendo dia
    let ano = f.getFullYear(); //obteniendo año
    if (dia < 10) dia = "0" + dia; //agrega cero si el menor de 10
    if (mes < 10) mes = "0" + mes; //agrega cero si el menor de 10
    document.getElementById("fecha").value = ano + "-" + mes + "-" + dia;
    this.setState({
      empleados: this.props.empleados,
    });
  }
  //elimina un producto de los detalles
  delete(id) {
    this.setState({
      productosSeleccionados: this.state.productosSeleccionados.filter(
        (producto) => producto.Id !== id
      ),
    });
  }

  seleccionarEmpleado(empleado) {
    this.setState({
      encargado: empleado,
      encargadoNombre: empleado.Name,
      empleadoElegido: true,
    });
  }
  seleccionarProducto(producto) {
    this.setState({
      ...this.state,
      productosSeleccionados: this.state.productosSeleccionados.concat({
        Name: producto.Name,
        Id: producto.Id,
        Description: producto.Description,
        Barcode: producto.Barcode,
        Cantidad: "1",
      }),
    });
    this.setState({ buscador: "" });
  }
  render() {
    return (
        <div className="darDeBaja ">
        <div className="row">
          <div className="col-md-4"></div>
          <div className="col-md-8">
            <h3>Ingreso y Egreso de productos</h3>
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <input
              type="text"
              className="form-control"
              placeholder="Encargado"
              value={this.state.encargadoNombre}
              onChange={(e) =>
                this.setState({
                  encargadoNombre: e.target.value,
                  empleadoElegido: false,
                })
              }
            />
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
          <div className="col-md-8"></div>
        </div>

        <div className="row">
          <div className="StockBody MateriaPima col-md-4">
            <table className="table table-hover ">
              <tbody className="tableBody">
                {this.state.encargadoNombre !== "" &&
                !this.state.empleadoElegido
                  ? this.state.empleados
                      .filter(
                        (empleado) =>
                          empleado.Name.toLowerCase().indexOf(
                            this.state.encargadoNombre.toLowerCase()
                          ) !== -1
                      )
                      .map((p) => (
                        <tr
                          key={p.Id}
                          onClick={() => this.seleccionarEmpleado(p)}
                        >
                          <td>{p.Name}</td>
                          <td>{p.CI}</td>
                        </tr>
                      ))
                  : null}
              </tbody>
            </table>
          </div>
        </div>

        <div className="row">
          <div className="col-md-4">
            <input
              type="text"
              className="form-control"
              placeholder="Observacion(Opcional)"
              value={this.state.observacion}
              onChange={(e) => this.setState({ observacion: e.target.value })}
            />
          </div>
          <div className="col-md-4">
          <label className="radio-inline"><input type="radio" name="optradio" checked/>Ingreso</label>
<label className="radio-inline"><input type="radio" name="optradio"/>Egreso</label>
          </div>
          

          <div className="col-md-4"></div>
        </div>
        <TablaProductoSelector productos={this.state.productosSeleccionados} delete={this.delete.bind(this)}/>

        <div className="row">
          <div className="col-md-4">
            <input
              className="form-control form-control-sm  buscador"
              type="text"
              id="id1"
              placeholder="Añadir producto"
              onChange={(e) => {
                this.setState({ buscador: e.target.value });
              }}
              value={this.state.buscador}
            />
          </div>

          <div className="col-md-4"></div>

          <div className="col-md-3">
            <button
              className="btn btn-primary"
              style={{ marginTop: 20 }}
              onClick={() => this.enviar()}
            >
              Guardar
            </button>
          </div>
        </div>
        <div className="row">
          <div className="StockBody MateriaPima col-md-4">
            <table className="table table-hover ">
              <tbody className="tableBody">
                {this.state.buscador !== ""
                  ? this.state.productos
                      .filter(
                        (producto) =>
                          producto.Name.toLowerCase().indexOf(
                            this.state.buscador.toLowerCase()
                          ) !== -1
                      )
                      .filter(
                        (producto) =>
                          this.state.productosSeleccionados.find(
                            (e) => e.Id === producto.Id
                          ) === undefined
                      )
                      .map((p) => (
                        <tr
                          key={p.Id}
                          onClick={() => this.seleccionarProducto(p)}
                        >
                          <td>{p.Id}</td>
                          <td>{p.Name}</td>
                          <td>{p.Description}</td>
                          <td>{p.Cost}</td>
                          <td>{p.Barcode}</td>
                        </tr>
                      ))
                  : null}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    );
  }
}
const mapStateToProps = (state) => {
    return {
      productos: state.productos,
      empleados: state.empleados,
    };
  };
  const mapDispatchToProps = {
    getEmpleados,
    getProductos,
  };

export default connect(mapStateToProps, mapDispatchToProps)(DarDeBaja);
