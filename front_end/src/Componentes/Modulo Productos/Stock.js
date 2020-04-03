import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import "./styleMProductos.css";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import ThumbDownIcon from "@material-ui/icons/ThumbDown";
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
  getProductosEnProduccion
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
      listaComponentes:[],
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
      detallesModalVisible: false
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
    this.setState({ productos: this.props.productos });
    this.setState({ capitalTotal: this.props.capitalTotal });
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
    this.setState({ nombreBtn: "Materia Prima" });
    this.setState({ productos: this.props.materias_primas });
    this.setState({ capitalTotal: this.props.capitalDeposito });
  }
  /**muestra todos los productos terminados con su capital total */
  async mostrarProductosTerminados() {
    await this.props.getCapitalDeposito(3);
    this.setState({ nombreBtn: "Terminados" });
    this.setState({ productos: this.props.productos_terminados });
    this.setState({ capitalTotal: this.props.capitalDeposito });
  }
  /**muestra los productos del deposito en produccion */
  async mostrarProductosEnProduccion() {
    await this.props.getCapitalDeposito(2);
    this.setState({ nombreBtn: "En Produccion" });
    this.setState({ productos: this.props.productos_en_produccion });
    this.setState({ capitalTotal: this.props.capitalDeposito });
  }
  /**setea los estados para ver los detalles del producto seleccionado */
  mostrarDetallesProducto(p){
    this.setState({
      nombreProductoActual: p.NameP,
      descripcionProductoActual: p.DescriptionP,
      IdProductoActual: p.Id,
      costoProductoActual: p.Cost,
      cantidadMinProductoActual: p.QuantityMin,
      barcodeProductoActual: p.Barcode,
      tipoProductoActual: p.ProductType.Id,
      nombreTipoProductoActual: p.ProductType.TypeP,
      detallesModalVisible: true,
      listaComponentes:p.listaComponentes,

    })
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
      this.setState({ capitalTotal: this.props.capitalDeposito });
    } else if (this.state.nombreBtn === "Terminados") {
      await this.props.getCapitalDeposito(3);
      this.setState({ productos: this.props.productos_terminados });
      this.setState({ capitalTotal: this.props.capitalDeposito });
    } else if (this.state.nombreBtn === "En Produccion") {
      await this.props.getCapitalDeposito(2);
      this.setState({ productos: this.props.productos_en_produccion });
      this.setState({ capitalTotal: this.props.capitalDeposito });
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
      NameP: this.state.nombreProductoActual,
      DescriptionP: this.state.descripcionProductoActual,
      Cost: this.state.costoProductoActual,
      QuantityMin: this.state.cantidadMinProductoActual,
      Barcode: this.state.barcodeProductoActual,
      IdProductType: this.state.tipoProductoActual
    });
    /**actualizo los cambios */
    this.actualizar();
    /**ocultar el modal de editar */
    this.setState({ editarModalVisible: false });
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
          
          <textarea className="form-control detalles" rows="3">{this.state.listaComponentes}</textarea>
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
    /*Modal para preguntar cuantos productos desea dar de baja*/
    const darBajaModal = (
      <Modal isOpen={this.state.darBajaModalVisible} centered>
        <ModalHeader>Cantidad a dar de baja</ModalHeader>
        <ModalBody>
          {/**INPUT PARA INGRESAR LA CANTIDAD DE PRODUCTOS QUE SE QUIERE DAR DE BAJA*/}
          <input
            type="text"
            className="form-control"
            placeholder="Cantidad a dar de baja"
          />
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.setState({ darBajaModalVisible: false })}>
            Aceptar
          </button>
          <button onClick={() => this.setState({ darBajaModalVisible: false })}>
            Cancelar
          </button>
        </ModalFooter>
      </Modal>
    );

    /**Modal para preguntar si desea eliminar el producto */
    const eliminarAlert = (
      <Modal isOpen={this.state.eliminarModalVisible} centered>
        <ModalHeader>
          Desea eliminar el producto {this.state.barcodeProductoActual}?
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
                  onChange={e => {
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
                  onChange={e => {
                    this.setState({
                      descripcionProductoActual: e.target.value
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
                  onChange={e => {
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
                  onChange={e => {
                    this.setState({
                      cantidadMinProductoActual: e.target.value
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
                  onChange={e => {
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
        {darBajaModal}
        {detallesModal}
        {/**representa la cabecera del stock con un buscador y un seleccionador de deposito actual */}
        <div className="StockCabecera row ">
          <div className="col-md-3"></div>
          <div className="col-md-3">
            {/**Un seleccionador que nos permite ver el tipo de producto que elijamos */}
            <div className="dropdown seleccionador">
              <button
                className="btn btn-secondary dropdown-toggle"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                {this.state.nombreBtn}
              </button>
              <div
                className="dropdown-menu"
                aria-labelledby="dropdownMenuButton"
              >
                <p
                  onClick={() => this.mostrarTodos()}
                  className="dropdown-item"
                  href="#todos"
                >
                  Todos
                </p>
                <p
                  onClick={() => this.mostrarMateriasPrimas()}
                  className="dropdown-item"
                >
                  Materia prima
                </p>
                <p
                  onClick={() => this.mostrarProductosEnProduccion()}
                  className="dropdown-item"
                >
                  En produccion
                </p>
                <p
                  onClick={() => this.mostrarProductosTerminados()}
                  className="dropdown-item"
                >
                  Productos terminados
                </p>
              </div>
            </div>
          </div>
          {/**Un buscador de productos */}
          <div className="col-md-4">
            <input
              className="form-control form-control-sm  buscador"
              type="text"
              placeholder="Search"
              aria-label="Search"
              value={this.state.buscador}
              onChange={e => {
                this.setState({ buscador: e.target.value });
              }}
            />
          </div>
        </div>
        {/**La tabla para listar los productos */}
        <div className="StockBody">
          <table className="table table-hover table-dark">
            <thead className="tableHeader">
              <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Costo</th>
                <th scope="col">Cantidad Minima</th>
                <th scope="col">Codigo de barra</th>
                <th scope="col"></th>
              </tr>
            </thead>
            {/**Mapeo el arreglo de productos que nos proporciona la api y muestro los productos en la tabla */}
            <tbody className="tableBody">
              {this.state.productos
                .filter(
                  producto =>
                    producto.NameP.toLowerCase().indexOf(
                      this.state.buscador.toLowerCase()
                    ) !== -1
                )
                .map(p => (
                  <tr
                    key={p.Id}
                    
                  >
                  
                    <td>{p.Id}</td>
                    <td onClick={() =>this.mostrarDetallesProducto(p)}>{p.NameP}</td>
                    <td onClick={() =>this.mostrarDetallesProducto(p)}>{p.DescriptionP}</td>
                    <td onClick={() =>this.mostrarDetallesProducto(p)}>{p.Cost}</td>
                    <td onClick={() =>this.mostrarDetallesProducto(p)}>{p.QuantityMin}</td>
                    <td onClick={() =>this.mostrarDetallesProducto(p)}>{p.Barcode}</td>
                   
                    <td>
                      {/**Iconos para editar dicho producto, eliminarlo o darlo de baja */}
                      <EditIcon
                        className="icono"
                        onClick={() =>
                          this.setState({
                            nombreProductoActual: p.NameP,
                            descripcionProductoActual: p.DescriptionP,
                            IdProductoActual: p.Id,
                            costoProductoActual: p.Cost,
                            cantidadMinProductoActual: p.QuantityMin,
                            barcodeProductoActual: p.Barcode,
                            tipoProductoActual: p.ProductType.Id,
                            nombreTipoProductoActual: p.ProductType.TypeP,
                            editarModalVisible: true,
                            listaComponentes:p.listaComponentes,

                          })
                        }
                      />
                      <DeleteIcon
                        onClick={() =>
                          this.setState({
                            nombreProductoActual: p.NameP,
                            descripcionProductoActual: p.DescriptionP,
                            IdProductoActual: p.Id,
                            costoProductoActual: p.Cost,
                            cantidadMinProductoActual: p.QuantityMin,
                            barcodeProductoActual: p.Barcode,
                            eliminarModalVisible: true,
                            nombreTipoProductoActual: p.ProductType.TypeP,
                            tipoProductoActual: p.ProductType.Id,
                            listaComponentes:p.listaComponentes,

                          })
                        }
                        className="icono"
                      />
                      <ThumbDownIcon
                        onClick={() =>
                          this.setState({
                            darBajaModalVisible: true,
                            nombreProductoActual: p.NameP,
                            descripcionProductoActual: p.DescriptionP,
                            IdProductoActual: p.Id,
                            costoProductoActual: p.Cost,
                            cantidadMinProductoActual: p.QuantityMin,
                            barcodeProductoActual: p.Barcode,
                            nombreTipoProductoActual: p.ProductType.TypeP,
                            tipoProductoActual: p.ProductType.Id,
                            listaComponentes:p.listaComponentes,

                          })
                        }
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
          Capital total: {this.state.capitalTotal}GS
        </div>
      </div>
    );
  }
}
/**Redux */
const mapStateToProps = state => {
  return {
    productos: state.productos,
    materias_primas: state.materias_primas,
    productos_terminados: state.productos_terminados,
    productos_en_produccion: state.productos_en_produccion,
    capitalTotal: state.capitalTotal,
    capitalDeposito: state.capitalDeposito
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
  editProducto
};

export default connect(mapStateToProps, mapDispatchToProps)(Stock);
