import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import "./styleMProductos.css";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";

import { connect } from "react-redux";
import {
  /**Edita un producto */
  editProducto,
  /**nos devuelve el capital total de productos existentes */
  getCapitalTotal,
  /**nos devuelve el capital total de productos en un deposito en especifico */
  getCapitalDeposito,
  /**devuelve todos los productos */
  getProductos,
  /**funcion que elimina un producto pasandole el Id */
  deleteProducto,
  /**Trae solo los productos del deposito de materia prima */
  getMateriasPrimas,
  /**Trae solo los productos del deposito de Productos terminados */
  getProductosTerminados,
  /**Trea solo los productos que estan en el deposito de produccion en proceso */
  getProductosEnProduccion,
} from "../../Redux/actions.js";
class Stock extends Component {
  constructor(props) {
    super(props);
    this.state = {
      /**El producto seleccionado */
      IdProductoActual: 0,
      descripcionProductoActual: "",
      cantidadMinProductoActual: 0,
      barcodeProductoActual: "",
      nombreProductoActual: "",
      costoProductoActual: "",
      tipoProductoActual: 0,
      nombreTipoProductoActual: "",
      listaComponentes: [],
      /**El deposito actual en el que nos encontramos, Todos, Materia prima, En produccion o productos terminados */
      nombreBtn: "Todos",
      /**guarda todos los productos que nos trae la api */
      productos: this.props.productos,
      /**almacena la cadena de caracteres existentes en el buscador */
      buscador: "",
      /**capital total de los productos del deposito en el que nos encontramos actualmente */
      capitalTotal: 0,
      /**permite hacer visible u ocultar las alertas y modals */
      editarModalVisible: false,
      eliminarModalVisible: false,
      darBajaModalVisible: false,
      detallesModalVisible: false,
    };
  }
  /**Cuando se renderiza el componente actualizo todos los datos con la api */
  async componentDidMount() {
    await this.props.getProductos();
    await this.props.getMateriasPrimas();
    await this.props.getProductosTerminados();
    await this.props.getProductosEnProduccion();
    await this.props.getCapitalTotal();
    /**por defecto se mostraran todos los productos existentes */
    this.setState({
      productos: this.props.productos,
      capitalTotal: this.props.capitalTotal,
    });
  }
  /**Muestra todos los productos existentes con su capital total */
  mostrarTodos() {
    this.setState({ nombreBtn: "Todos" });
    this.setState({ productos: this.props.productos });
    this.setState({ capitalTotal: this.props.capitalTotal });
  }
  /**muestra solo productos materia prima con su capital */
  async mostrarMateriasPrimas() {
    /**el deposito 1 es el que tiene las materias primas */
    await this.props.getCapitalDeposito(1);
    this.setState({
      nombreBtn: "Materia Prima",
      productos: this.props.materias_primas,
      capitalTotal: this.props.capitalDeposito,
    });
  }
  /**muestra todos los productos terminados con su capital total */
  async mostrarProductosTerminados() {
    await this.props.getCapitalDeposito(3);
    this.setState({ nombreBtn: "Terminados" });
    this.setState({ productos: this.props.productos_terminados });
    this.setState({ capitalTotal: this.props.capitalDeposito });
  }
  //actializa los estados al seleccionar un producto
  seleccionarProducto(p) {
    this.setState({
      nombreProductoActual: p.Name,
      descripcionProductoActual: p.Description,
      IdProductoActual: p.Id,
      costoProductoActual: p.Cost,
      cantidadMinProductoActual: p.QuantityMin,
      barcodeProductoActual: p.Barcode,
      tipoProductoActual: p.ProductType.Id,
    });
  }
  /**muestra los productos del deposito en produccion */
  async mostrarProductosEnProduccion() {
    await this.props.getCapitalDeposito(2);
    this.setState({ nombreBtn: "En Produccion" });
    this.setState({ productos: this.props.productos_en_produccion });
    this.setState({ capitalTotal: this.props.capitalDeposito });
  }
  /**setea los estados para ver los detalles del producto seleccionado */
  mostrarDetallesProducto(p) {
    this.seleccionarProducto(p);
    this.setState({ detallesModalVisible: true });
  }
  async actualizar() {
    await this.props.getProductos();
    await this.props.getMateriasPrimas();
    await this.props.getProductosTerminados();
    await this.props.getProductosEnProduccion();
    await this.props.getCapitalTotal();
    if (this.state.nombreBtn === "Todos") {
      this.setState({ productos: this.props.productos });
      this.setState({ capitalTotal: this.props.capitalTotal });
      /**actualizo los datos dependiendo de en cual deposito estaba el usuario y lo pinto de vuelta */
    } else if (this.state.nombreBtn === "Materia Prima") {
      await this.props.getCapitalDeposito(1);
      this.setState({ productos: this.props.materias_primas });
      // this.setState({ capitalTotal: this.props.capitalDeposito });
    } else if (this.state.nombreBtn === "Terminados") {
      await this.props.getCapitalDeposito(3);
      this.setState({ productos: this.props.productos_terminados });
      // this.setState({ capitalTotal: this.props.capitalDeposito });
    } else if (this.state.nombreBtn === "En Produccion") {
      await this.props.getCapitalDeposito(2);
      this.setState({ productos: this.props.productos_en_produccion });
      // this.setState({ capitalTotal: this.props.capitalDeposito });
    }
  }
  /**elimino el producto si es que el usuario acepta y actualizo todos los datos con la api */
  async eliminarProducto() {
    await this.props.deleteProducto(this.state.IdProductoActual);
    /**actualizo los datos */
    this.actualizar();
    /**ocultar el modal de eliminar */
    this.setState({ eliminarModalVisible: false });
  }
  /**Edito el un producto y actualizo la tabla */
  async editarProducto() {
    await this.props.editProducto(this.state.IdProductoActual, {
      Name: this.state.nombreProductoActual,
      Description: this.state.descripcionProductoActual,
      Cost: this.state.costoProductoActual,
      QuantityMin: this.state.cantidadMinProductoActual,
      Barcode: this.state.barcodeProductoActual,
      ProductTypeId: this.state.tipoProductoActual,
    });
    /**actualizo los cambios */
    this.actualizar();
    /**ocultar el modal de editar */
    this.setState({ editarModalVisible: false });
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
    /**Modal que permite ver los detalles de un producto seleccionado */
    const detallesModal = (
      <Modal isOpen={this.state.detallesModalVisible} centered>
        <ModalHeader>Detalles del Producto</ModalHeader>
        <ModalBody>
          <b> Nombre:</b> {this.state.nombreProductoActual}
          <br />
          <b>Descripcion:</b> {this.state.descripcionProductoActual}
          <br />
          <b>Cantidad Minima:</b> {this.state.cantidadMinProductoActual}
          <br />
          <b>Codigo de Barra:</b> {this.state.barcodeProductoActual}
          <br />
          <b>Tipo de Producto:</b> {this.state.nombreTipoProductoActual}
          <br />
          <b>Costo:</b> {this.state.costoProductoActual}
          <br />
          <textarea className="form-control detalles" rows="3">
           
          </textarea>
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

    /**Modal para preguntar si desea eliminar el producto */
    const eliminarAlert = (
      <Modal isOpen={this.state.eliminarModalVisible} centered>
        <ModalHeader>
          Desea eliminar el producto {this.state.barcodeProductoActual}-
          {this.state.nombreProductoActual}?
        </ModalHeader>
        <ModalFooter>
          <button onClick={() => this.eliminarProducto()}>Si</button>
          <button
            onClick={() => this.setState({ eliminarModalVisible: false })}
          >
            No
          </button>
        </ModalFooter>
      </Modal>
    );
    /**Un modal que permite al usuario la facilidad de editar el producto que elija */
    const editarModal = (
      <Modal isOpen={this.state.editarModalVisible} centered>
        <ModalHeader>Editar Producto</ModalHeader>
        <ModalBody>
          <form>
            <div className="form-row">
              <div className="col-md-6">
                {/**NOMBRE DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  placeholder="Nombre del Producto"
                  value={this.state.nombreProductoActual}
                  onChange={(e) => {
                    this.setState({ nombreProductoActual: e.target.value });
                  }}
                />
              </div>
              <div className="col-md-6">
                {/**DESCRIPCION DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  placeholder="Descripcion del producto"
                  value={this.state.descripcionProductoActual}
                  onChange={(e) => {
                    this.setState({
                      descripcionProductoActual: e.target.value,
                    });
                  }}
                />
              </div>
              <div className="col-md-6">
                {/**COSTO DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  placeholder="Costo"
                  value={this.state.costoProductoActual}
                  onChange={(e) => {
                    this.setState({ costoProductoActual: e.target.value });
                  }}
                />
              </div>
              <div className="col-md-6">
                {/**CANTIDAD MINIMA DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  placeholder="Cantidad Minima"
                  value={this.state.cantidadMinProductoActual}
                  onChange={(e) => {
                    this.setState({
                      cantidadMinProductoActual: e.target.value,
                    });
                  }}
                />
              </div>
              <div className="col-md-6">
                {/**CODIGO DE BARRA DEL PRODUCTO*/}
                <input
                  type="text"
                  className="form-control"
                  placeholder="Codigo de barra"
                  value={this.state.barcodeProductoActual}
                  onChange={(e) => {
                    this.setState({ barcodeProductoActual: e.target.value });
                  }}
                />
              </div>
              <div className="col-md-12"></div>
            </div>
          </form>
        </ModalBody>
        <ModalFooter>
          <button className="primary" onClick={() => this.editarProducto()}>
            Agregar Cambios
          </button>
          <button
            className="exit"
            onClick={() => this.setState({ editarModalVisible: false })}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>
    );
    return (
      <div className="stock">
        {/**Los modals y las alertas en estado visible=false, con acciones se modificara dicho estado */}
        {editarModal}
        {eliminarAlert}
        {detallesModal}
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
                    {this.state.nombreBtn}
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
                      onClick={() => this.mostrarMateriasPrimas()}
                    >
                      Materia Prima
                    </a>
                    <a
                      className="dropdown-item"
                      href="#"
                      onClick={() => this.mostrarProductosEnProduccion()}
                    >
                      En Produccion
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
                  (producto) =>
                    producto.Name.toLowerCase().indexOf(
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
            <span className="form-control">{this.state.capitalTotal}</span>
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
    materias_primas: state.materias_primas,
    productos_terminados: state.productos_terminados,
    productos_en_produccion: state.productos_en_produccion,
    capitalTotal: state.capitalTotal,
    capitalDeposito: state.capitalDeposito,
  };
};
const mapDispatchToProps = {
  getProductos,
  deleteProducto,
  getMateriasPrimas,
  getProductosTerminados,
  getProductosEnProduccion,
  getCapitalTotal,
  getCapitalDeposito,
  editProducto,
};

export default connect(mapStateToProps, mapDispatchToProps)(Stock);
