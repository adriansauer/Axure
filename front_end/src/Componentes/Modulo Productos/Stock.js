import React, { Component } from "react";
import "./styleMProductos.css";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import { connect } from "react-redux";
import DetallesModal from "./Modales/ProductoDetalles.js";
import EditarModal from "./Modales/EditarProducto.js";
import EliminarModal from "./Modales/EliminarProducto.js";
import { getProductos, getProductosDeposito } from "../../Redux/actions.js";
import api from "../../Axios/Api.js";
class Stock extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productoActual: {
        Id: "",
        Name: "",
        Description: "",
        Cost: "",
        ProductType: {
          Id: "",
        },
        Barcode: "",
        QuantityMin: "",
      },
      selector: 4,
      nombreSelector: "Todos",
      productos: this.props.productos,
      buscador: "",
      capital: 0,
      editarModalVisible: false,
      eliminarModalVisible: false,
      detallesModalVisible: false,
    };
  }
  async componentDidMount() {
    await this.props.getProductos();

    const capital1 = await api.productos.getCapital(1);
    const capital2 = await api.productos.getCapital(3);

    const capitalTotal = capital1.data.Sum + capital2.data.Sum;
    this.setState({
      productos: this.props.productos,
      capital: capitalTotal,
    });
  }

  seleccionarProducto(p) {
    this.setState({
      productoActual: p,
    });
  }
  ocultarModals() {
    this.setState({
      detallesModalVisible: false,
      editarModalVisible: false,
      eliminarModalVisible: false,
    });
  }

  async actualizar() {
    await this.props.getProductos();
    if (this.state.selector < 4) {
      await this.props.getProductosDeposito(this.state.selector);
      const capital = await api.productos.getCapital(this.state.selector);

      this.setState({
        productos: this.props.productosDeposito,
        capital: capital.data.Sum,
      });
    } else {
      const capital1 = await api.productos.getCapital(1);
      const capital2 = await api.productos.getCapital(3);

      const capitalTotal = capital1.data.Sum + capital2.data.Sum;
      this.setState({
        productos: this.props.productos,
        capital: capitalTotal,
      });
    }
  }
  mostrarProductosTerminados() {
    this.setState({
      selector: 3,
      nombreSelector: "ProductosTerminados",
    });
    this.actualizar();
  }
  mostrarMateriaPrima() {
    this.setState({
      selector: 1,
      nombreSelector: "Materia Prima",
    });
    this.actualizar();
  }
  mostrarTodos() {
    this.setState({
      selector: 4,
      nombreSelector: "Todos",
    });
    this.actualizar();
  }
  mostrarDetallesProducto(p) {
    this.seleccionarProducto(p);
    this.setState({ detallesModalVisible: true });
  }
  editar(p) {
    this.seleccionarProducto(p);
    this.setState({ editarModalVisible: true });
  }
  eliminar(p) {
    this.seleccionarProducto(p);
    this.setState({ eliminarModalVisible: true });
  }

  render() {
    return (
      <div className="stock">
        <EliminarModal
          producto={this.state.productoActual}
          visible={this.state.eliminarModalVisible}
          ocultar={this.ocultarModals.bind(this)}
          actualizar={this.actualizar.bind(this)}
        />
        <DetallesModal
          producto={this.state.productoActual}
          visible={this.state.detallesModalVisible}
          ocultar={this.ocultarModals.bind(this)}
        />
        <EditarModal
          producto={this.state.productoActual}
          visible={this.state.editarModalVisible}
          ocultar={this.ocultarModals.bind(this)}
          actualizar={this.actualizar.bind(this)}
        />
        {/**representa la cabecera del stock con un buscador y un seleccionador de deposito actual */}
        <div className="StockCabecera row ">
          <div className="col-md-6 mr-auto pl-0">
            {/**Un buscador de productos */}
            <div className="col-sm-12 pl-0">
              <div className="input-group mb-3">
                <input
                  type="text"
                  className="form-control buscador"
                  aria-label="Busqueda"
                  placeholder="Busqueda..."
                  aria-label="Busqueda"
                  value={this.state.buscador}
                  onChange={(e) => {
                    this.setState({ buscador: e.target.value });
                  }}
                />
                <div className="input-group-append">
                  <button
                    className="btn btn-outline-secondary dropdown-toggle"
                    type="button"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >
                    {this.state.nombreSelector}
                  </button>
                  <div className="dropdown-menu">
                    <a
                      className="dropdown-item"
                      href="#todos"
                      onClick={() => this.mostrarTodos()}
                    >
                      Todos
                    </a>
                    <a
                      className="dropdown-item"
                      href="#"
                      onClick={() => this.mostrarMateriaPrima()}
                    >
                      Materia Prima
                    </a>
                    <a
                      className="dropdown-item"
                      href="#"
                      onClick={() => this.mostrarProductosTerminados()}
                    >
                      Productos Terminados
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        {/**La tabla para listar los productos */}
        <div className="StockBody">
          <table className="table table-hover table">
            <thead className="tableHeader">
              <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Costo</th>
                <th scope="col">Cantidad Minima</th>
                <th scope="col">Codigo de barra</th>
                <th scope="col">Acciones</th>
              </tr>
            </thead>
            {/**Mapeo el arreglo de productos que nos proporciona la api y muestro los productos en la tabla */}
            <tbody className="tableBody">
              {this.state.productos
                .filter(
                  (p) =>
                    p.Name.toLowerCase().indexOf(
                      this.state.buscador.toLowerCase()
                    ) !== -1
                )
                .map((p) => (
                  <tr key={p.Id}>
                    <td>{p.Id}</td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.Name}
                    </td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.Description}
                    </td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.Cost}
                    </td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.QuantityMin}
                    </td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.Barcode}
                    </td>

                    <td>
                      {/**Iconos para editar dicho producto, eliminarlo o darlo de baja */}
                      <EditIcon
                        className="icono"
                        onClick={() => this.editar(p)}
                      />
                      <DeleteIcon
                        onClick={() => this.eliminar(p)}
                        className="icono"
                      />
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
        {/**El footer de stock nos muestra el capital total del deposito en el cual nos encontramos */}
        <div className="StockFooter">
          <div className="input-group">
            <div className="input-group-prepend">
              <span className="input-group-text" id="basic-addon1">
                Capital Total:
              </span>
            </div>
            <span className="form-control">{this.state.capital}</span>
            <div className="input-group-append">
              <span className="input-group-text" id="basic-addon1">
                GS
              </span>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
/**Redux */
const mapStateToProps = (state) => {
  return {
    productos: state.productos,
    productosDeposito: state.productoDeDeposito,
    capital: state.capitalDeposito,
  };
};
const mapDispatchToProps = {
  getProductos,
  getProductosDeposito,
};

export default connect(mapStateToProps, mapDispatchToProps)(Stock);
