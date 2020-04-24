import React, { Component } from "react";
import "./styleMProductos.css";
import { connect } from "react-redux";
import api from "../../Axios/Api.js";
import { getEmpleados } from "../../Redux/actions.js";
import VisibilityIcon from "@material-ui/icons/Visibility";
import DeleteIcon from "@material-ui/icons/Delete";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";

class GenerarOrdenProduccion extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: this.props.productos_terminados,
      buscador: "",
      productosSeleccionados: [],
      observacion: "",
      encargado: {},
      encargadoNombre: "",
      empleados: [],
      empleadoElegido: false,
      detallesModalVisible: false,
      productoSeleccionado: {
        Name: "",
        Description: "",
        Cost: "",
        Barcode: "",
        QuantityMin: "",
      },
    };
  }
  async componentDidMount() {
    await this.props.getEmpleados();

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
  async enviar() {
    let date = new Date(document.getElementById("fecha").value);
    const productos = this.state.productosSeleccionados.map((p) => {
      return {
        ProductId: p.Id,
        Quantity: parseInt(p.Cantidad),
      };
    });

    if (this.validarCampos()) {
      const request = await api.ordenProduccion.create({
        ProductionStateId: 1,
        EmployeeId: this.state.encargado.Id,
        Day: date.getDate() + 1,
        Month: date.getMonth() + 1,
        Year: date.getFullYear(),
        Observation: this.state.observacion,
        ListDetails: productos,
      });
      console.log("Respuesta=" + request);
      if (request.state === 200) {
        this.setState({});
        console.log("Orgen guardada con exito");
      }
    }
  }
  render() {
    /**Modal que permite ver los detalles de un producto seleccionado */
    const detallesModal = (
      <Modal isOpen={this.state.detallesModalVisible} centered>
        <ModalHeader>Detalles del Producto</ModalHeader>
        <ModalBody>
          <b> Nombre:</b> {this.state.productoSeleccionado.Name}
          <br />
          <b>Descripcion:</b> {this.state.productoSeleccionado.Description}
          <br />
          <b>Codigo de Barra:</b> {this.state.productoSeleccionado.Barcode}
          <br />
          <textarea className="form-control detalles" rows="3"></textarea>
        </ModalBody>
        <ModalFooter>
          <button
            onClick={() => this.setState({ detallesModalVisible: false })}
          >
            Cerrar
          </button>
        </ModalFooter>
      </Modal>
    );
    return (
      <div className="generarOrdenProduccion ">
        {detallesModal}
        <div className="row">
          <div className="col-md-4"></div>
          <div className="col-md-8">
            <h3>Generar Orden Produccion</h3>
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

          <div className="col-md-8"></div>
        </div>
        <div className="row">
          <table className="table table-hover table" style={{ marginTop: 50 }}>
            <thead className="tableHeader">
              <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Codigo de barra</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            <tbody className="tableBody">
              {this.state.productosSeleccionados.map((p) => (
                <tr key={p.Id}>
                  <td>{p.Id}</td>
                  <td>{p.Name}</td>
                  <td>{p.Description}</td>
                  <td>{p.Barcode}</td>

                  {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                  <td>
                    <input
                      type="text"
                      className="form-control"
                      placeholder="Cantidad"
                      value={p.Cantidad}
                      onChange={(e) => {
                        const arreglo = this.state.productosSeleccionados;
                        arreglo[arreglo.indexOf(p)] = {
                          Name: p.Name,
                          Id: p.Id,
                          Description: p.Description,
                          Barcode: p.Barcode,
                          Cantidad: e.target.value,
                        };
                        this.setState({
                          productosSeleccionados: arreglo,
                        });
                      }}
                    />
                  </td>
                  {/**Boton para sacar de la lista el producto */}
                  <td>
                    <VisibilityIcon
                      onClick={() =>
                        this.setState({
                          productoSeleccionado: p,
                          detallesModalVisible: true,
                        })
                      }
                    />
                    <DeleteIcon onClick={() => this.delete(p.Id)} />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
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
    productos_terminados: state.productos_terminados,
    empleados: state.empleados,
  };
};
const mapDispatchToProps = {
  getEmpleados,
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(GenerarOrdenProduccion);
