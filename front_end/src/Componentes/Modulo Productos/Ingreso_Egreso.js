import React, { Component } from "react";
import { connect } from "react-redux";
import { getEmpleados } from "../../Redux/actions.js";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import Tabla from "./Tabla_Ingreso_EgresoSelector";

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
      tipo_movimiento: 1,
      deposito: 3,
      nombreMovimientoBtn: "Ingreso",
      nombreDepositoBtn: "Deposito de productos terminados",
    };
  }

async enviar() {
  let date = new Date(document.getElementById("fecha").value);
  const productos = this.state.productosSeleccionados.map((p) => {
    return {
      ProductId: p.Id,
      Quantity: parseInt(p.Cantidad),
      Observation:p.ObservacionDetalle,
    };
  });
const envio={
  DepositId:this.state.deposito,
  MovementTypeId:this.state.tipo_movimiento,
EmployeeId: this.state.encargado.Id,
Day: date.getDate() + 1,
Month: date.getMonth() + 1,
Year: date.getFullYear(),
Observation: this.state.observacion,
ListDetails: productos,
}
  if (this.validarCampos()) {
    const request = await api.ingreso_egreso.create(envio);
    if (request.status === 200) {
      this.setState({
        buscador: "",
        productosSeleccionados: [],
        observacion: "",
        encargado: {},
        encargadoNombre: "",
        empleadoElegido: false,
      });
      console.log("Orden guardada con exito");
    }
  }
}
  async componentDidMount() {
    await this.props.getEmpleados();
    const p = await api.productos.getDeposito(this.state.deposito);
    const f = new Date();

    let mes = f.getMonth() + 1; //obteniendo mes
    let dia = f.getDate(); //obteniendo dia
    let ano = f.getFullYear(); //obteniendo año
    if (dia < 10) dia = "0" + dia; //agrega cero si el menor de 10
    if (mes < 10) mes = "0" + mes; //agrega cero si el menor de 10
    document.getElementById("fecha").value = ano + "-" + mes + "-" + dia;
    this.setState({
      productos: p.data,
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
        ObservacionDetalle: "",
      }),
    });
    this.setState({ buscador: "" });
  }
  validarCampos() {
    if (
      this.state.productosSeleccionados.length === 0 ||
      this.state.encargadoNombre === "" ||
      document.getElementById("fecha").value === ""
    ) {
      console.log("Rellene todos los campos");
      return false;
    }
    return true;
  }
  async cambiarDeposito(id, nombre) {
    console.log(this.state.deposito);
    console.log(id);
    if (id !== this.state.deposito) {
      const p = await api.productos.getDeposito(id);
      this.setState({
        productosSeleccionados: [],
        productos: p.data,
        nombreDepositoBtn: nombre,
        deposito:id,
      });
    }
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
              placeholder="Observacion"
              value={this.state.observacion}
              onChange={(e) => this.setState({ observacion: e.target.value })}
            />
          </div>
          <div className="col-md-1">
            <div className="dropdown">
              <button
                className="btn btn-secondary dropdown-toggle"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                {this.state.nombreMovimientoBtn}
              </button>
              <div
                className="dropdown-menu"
                aria-labelledby="dropdownMenuButton"
              >
                <a
                  onClick={() =>
                    this.setState({
                      nombreMovimientoBtn: "Ingreso",
                      tipo_movimiento: 1,
                    })
                  }
                  className="dropdown-item"
                  href="#"
                >
                  Ingreso
                </a>
                <a
                  onClick={() =>
                    this.setState({
                      nombreMovimientoBtn: "Egreso",
                      tipo_movimiento: 2,
                    })
                  }
                  className="dropdown-item"
                  href="#"
                >
                  Egreso
                </a>
              </div>
            </div>
          </div>
          <div className="col-md-3">
            <div className="dropdown">
              <button
                className="btn btn-secondary dropdown-toggle"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                {this.state.nombreDepositoBtn}
              </button>
              <div
                className="dropdown-menu"
                aria-labelledby="dropdownMenuButton"
              >
                <a
                  onClick={() =>
                    this.cambiarDeposito(3, "Deposito de productos terminados")
                  }
                  className="dropdown-item"
                  href="#"
                >
                  Deposito de productos terminados
                </a>
                <a
                  onClick={() =>
                    this.cambiarDeposito(1, "Deposito de materia prima")
                  }
                  className="dropdown-item"
                  href="#"
                >
                  Deposito de materia prima
                </a>
              </div>
            </div>
          </div>

          <div className="col-md-4"></div>
        </div>
        <Tabla
          productos={this.state.productosSeleccionados}
          delete={this.delete.bind(this)}
        />

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
    empleados: state.empleados,
  };
};
const mapDispatchToProps = {
  getEmpleados,
};

export default connect(mapStateToProps, mapDispatchToProps)(DarDeBaja);
