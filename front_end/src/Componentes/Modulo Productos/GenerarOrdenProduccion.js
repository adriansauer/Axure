import React, { Component } from "react";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import TablaProductoSelector from "./TablaProductoSelector.js";
import Notificacion,{notify} from "../Notificacion.js";
class GenerarOrdenProduccion extends Component {
  constructor(props) {
    super(props);
    this.state = {
      
      buscador: "",
      productosSeleccionados: [],
      observacion: "",
      encargado: {},
      encargadoNombre: "",
      empleados: [],
      empleadoElegido: false,
      productos:[],
    };
  }
  async componentDidMount() {
    const empleados=await api.empleados.get();
    const productos=await api.productos.getProductosDeVenta();
    const f = new Date();

    let mes = f.getMonth() + 1; //obteniendo mes
    let dia = f.getDate(); //obteniendo dia
    let ano = f.getFullYear(); //obteniendo año
    if (dia < 10) dia = "0" + dia; //agrega cero si el menor de 10
    if (mes < 10) mes = "0" + mes; //agrega cero si el menor de 10
    document.getElementById("fecha").value = ano + "-" + mes + "-" + dia;
    this.setState({
      empleados: empleados.data,
      productos:productos.data,
    });
  }
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
        Cost:producto.Cost,
        QuantityMin:producto.QuantityMin,
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
      notify("Rellene todos los campos!","warning");
      return false;
    }
    return true;
  }
  async enviar() {
    let date = new Date(document.getElementById("fecha").value);
    const productos = this.state.productosSeleccionados.map((p) => {
      return {
        ProductId: p.Id,
        Quantity: parseInt(p.Cantidad),
      };
    });
const envio={
  ProductionStateId: 1,
  EmployeeId: this.state.encargado.Id,
  Day: date.getDate() + 1,
  Month: date.getMonth() + 1,
  Year: date.getFullYear(),
  Observation: this.state.observacion,
  ListDetails: productos,
}
    if (this.validarCampos()) {
      const request = await api.ordenProduccion.create(envio);
      if (request.status === 200) {
        this.setState({
          buscador: "",
          productosSeleccionados: [],
          observacion: "",
          encargado: {},
          encargadoNombre: "",
          empleadoElegido: false,
        });
        notify("Orden guardada exitosamente!","success");
      }else{
        notify("Error al intentar guardar la orden!","danger");

      }
    }
  }
  toggleShow(param){
    
    if(document.getElementById(param)!==null){
        document.getElementById(param).classList.toggle("show");
    }
   
  }
  buscarEncargado(e){
    this.setState({
      encargadoNombre: e.target.value,
      empleadoElegido: false,
    })
    
      this.toggleShow("dropdown-encargado");
  }
  render() {
    return (
      <div className="generarOrdenProduccion ">
        <Notificacion/>
        <div className="row title-wrapper py-3">
          <div className="row bg-title">
            <label className="m-auto title-label">Generar Orden Produccion</label>
          </div>
        </div>
        <div className="content-wrapper">
          <div className="row row-group">
            <div className="col-sm-5">
              <div className="dropdown">
                <input
                  
                  type="text"
                  className="form-control"
                  placeholder="Encargado"
                  required="required"
                  value={this.state.encargadoNombre}
                  onChange={(e) =>
                    this.buscarEncargado(e)
                  }
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
                            href="#"
                          >
                            {p.Name},{p.CI}
                          </a>
                        ))
                    : null}
                </div>
              </div>
            </div>
            <div className="col-sm-3">
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
            <div className="col-md-4 form-state text-center">
              <label>Estado: Pendiente</label>
            </div>
          </div>
          <div className="row pb-3">
            <div className="col-md-12">
              <textarea
                type="text"
                className="form-control"
                placeholder="Observacion(Opcional)"
                value={this.state.observacion}
                onChange={(e) => this.setState({ observacion: e.target.value })}
              />
            </div>
          </div>
          <div className="dropdown-divider my-3"></div>
          <TablaProductoSelector productos={this.state.productosSeleccionados} delete={this.delete.bind(this)}/>

          <div className="row">
            <div className="col-sm-6">
              <div className="dropup">
                <input
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
                </div>
              </div>
            </div>
          </div>
            <div className="row">
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
        </div>
      </div>
    );
  }
}


export default GenerarOrdenProduccion;
