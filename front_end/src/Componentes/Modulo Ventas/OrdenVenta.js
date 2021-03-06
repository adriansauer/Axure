import React, { Component } from "react";
import "../Modulo Productos/styleMProductos.css";
import TablaProductoSelector from "../Modulo Productos/TablaProductoSelector";
import AgregarCliente from "./Modales/AgregarCliente.js";
import Api from "../../Axios/Api.js";
import Notificacion, { notify } from "../Notificacion.js";
class OrdenVenta extends Component {
  constructor(props) {
    super(props);
    this.state = {
      agregarClienteVisible: false,
      productosSeleccionados: [],
      buscador: "",
      empleados: [],
      clientes: [],
      productos: [],
      productosSeleccionado: [],
      encargadoNombre: "",
      encargado: {},
      encargadoElegido: false,
      clienteNombre: "",
      cliente: {},
      clienteElegido: false,
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

    await this.actualizar();
  }
  async actualizar() {
    try {
      const clientes = await Api.clientes.get();
      const empleados = await Api.empleados.get();
      const productos = await Api.productos.getProductosDeVenta();
      this.setState({
        clientes: clientes.data,
        empleados: empleados.data,
        productos: productos.data,
      });
    } catch (error) {
      notify("No se pudo conectar con la base de datos", "danger");
    }
  }
  seleccionarEmpleado(empleado) {
    this.setState({
      encargado: empleado,
      encargadoNombre: empleado.Name,
      encargadoElegido: true,
    });

    this.toggleShow("dropdown-encargado");
  }
  seleccionarCliente(cliente) {
    this.setState({
      cliente: cliente,
      clienteNombre: cliente.Name,
      clienteElegido: true,
    });

    this.toggleShow("dropdown-cliente");
  }
  toggleShow(param) {
    if (document.getElementById(param) !== null) {
      document.getElementById(param).classList.toggle("show");
    }
  }
  buscarEncargado(e) {
    this.setState({
      encargadoNombre: e.target.value,
      empleadoElegido: false,
    });

    this.toggleShow("dropdown-encargado");
  }
  buscarCliente(e) {
    this.setState({
      clienteNombre: e.target.value,
      clienteElegido: false,
    });

    this.toggleShow("dropdown-cliente");
  }
  validarCampos(){
    if(
      this.state.clienteElegido===false ||
      this.state.encargadoElegido===false ||
      this.state.productosSeleccionados.length===0
    ){
return false;
    }else{
      return true;
    }
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
        Cost: producto.Cost,
        QuantityMin: producto.QuantityMin,
      }),
    });
    this.setState({ buscador: "" });
  }
  delete(id) {
    this.setState({
      productosSeleccionados: this.state.productosSeleccionados.filter(
        (producto) => producto.Id !== id
      ),
    });
  }
  async ocultarModales() {
    this.setState({ agregarClienteVisible: false });
    await this.actualizar();
  }
  async enviar() {
    let date = new Date(document.getElementById("fecha").value);
    const productos = this.state.productosSeleccionados.map((p) => {
      return {
        ProductId: p.Id,
        Quantity: parseInt(p.Cantidad),
      };
    });
    const envio = {
      ClientId: this.state.cliente.Id,
      Day: date.getDate() + 1,
      Month: date.getMonth() + 1,
      Year: date.getFullYear(),
      EmployeeId: this.state.encargado.Id,
      OrderNumber: 2,
      ListDetails: productos,
    };
    if (this.validarCampos()) {
      try {
        const request = await Api.ordenes_venta.create(envio);
        if (request.status === 200) {
          this.setState({
            productosSeleccionados: [],
            buscador: "",
            productosSeleccionado: [],
            encargadoNombre: "",
            encargado: {},
            encargadoElegido: false,
            clienteNombre: "",
            cliente: {},
            clienteElegido: false,
          });
          notify("Orden guardada exitosamente!", "success");
        } else {
          notify("Error al intentar guardar la orden!", "danger");
        }
      } catch (error) {
        notify("Error al intentar guardar la orden!", "danger");
      }     
    }else{
      notify("Rellene todos los campos!", "warning");

    }
  }
  render() {

    return (
      <div className="Container">
        <Notificacion />
        <AgregarCliente
          ocultar={this.ocultarModales.bind(this)}
          visible={this.state.agregarClienteVisible}
        />
        <div className="row">
          <div className="col-md-4">
            <div className="dropdown">
              <input
                type="text"
                className="form-control"
                placeholder="Cliente"
                required="required"
                style={(this.state.clienteElegido)?{borderColor:"green"}:{borderColor:"red"}}
                value={this.state.clienteNombre}
                onChange={(e) => this.buscarCliente(e)}
              />
              <div className="dropdown-menu" id="dropdown-cliente">
                {this.state.clienteNombre !== "" && !this.state.clienteElegido
                  ? this.state.clientes
                      .filter(
                        (cliente) =>
                          cliente.Name.toLowerCase().indexOf(
                            this.state.clienteNombre.toLowerCase()
                          ) !== -1
                      )
                      .map((p) => (
                        <a
                          className="dropdown-item"
                          key={p.Id}
                          onClick={() => this.seleccionarCliente(p)}
                          href="#selected"
                        >
                          {p.Name},{p.RUC}
                        </a>
                      ))
                  : null}
              </div>
            </div>
          </div>
          <div className="col-md-2">
            <button
              className="btn btn-primary"
              onClick={() => this.setState({ agregarClienteVisible: true })}
            >
              Agregar Cliente
            </button>
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
            <div className="dropdown">
              <input
                type="text"
                className="form-control"
                placeholder="Encargado"
                style={(this.state.encargadoElegido)?{borderColor:"green"}:{borderColor:"red"}}
                required="required"
                value={this.state.encargadoNombre}
                onChange={(e) => this.buscarEncargado(e)}
              />
              <div className="dropdown-menu" id="dropdown-encargado">
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
                        <a
                          className="dropdown-item"
                          key={p.Id}
                          onClick={() => this.seleccionarEmpleado(p)}
                          href="#selected"
                        >
                          {p.Name},{p.CI}
                        </a>
                      ))
                  : null}
              </div>
            </div>
          </div>
        </div>

        <div className="row">
          <div className="col">
            <TablaProductoSelector
              productos={this.state.productosSeleccionados}
              delete={this.delete.bind(this)}
            />
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <div className="dropup">
              <input
                autoComplete="false"
                type="text"
                className="form-control form-control-sm buscador"
                id="id1"
                placeholder="Añadir producto"
                required="required"
                onChange={(e) => {
                  this.setState({ buscador: e.target.value });
                  this.toggleShow("dropdown-buscador");
                }}
                value={this.state.buscador}
              />
              <div className="dropdown-menu" id="dropdown-buscador">
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
                        <p
                          key={p.Id}
                          onClick={() => this.seleccionarProducto(p)}
                        >
                          {p.Name},{p.Description},{p.Barcode}
                        </p>
                      ))
                  : null}
              </div>
            </div>
          </div>

          <div className="col-md-4"></div>

          <div className="col-md-3">
            <button
            onClick={()=>this.enviar()}
            className="btn btn-primary" style={{ marginTop: 20 }}>
              Guardar
            </button>
          </div>
        </div>
      </div>
    );
  }
}

export default OrdenVenta;
