import React, { Component } from "react";
import "./styleMProductos.css";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import DetallesModal from "./Modales/ProductoDetalles.js";
import EditarModal from "./Modales/EditarProducto.js";
import EliminarModal from "./Modales/EliminarProducto.js";
import AgregarModal from "./Modales/AgregarProducto";
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
      selector: "MATERIAPRIMA",
      nombreSelector: "Materia Prima",
      productos: [],
      buscador: "",
      capital: 0,
      editarModalVisible: false,
      eliminarModalVisible: false,
      detallesModalVisible: false,
      agregarModalVisible:false,
    };
  }
  async componentDidMount() {
    const request = await api.productos.getMateriasPrimas();

    const depositoProduccionId = await api.settings.get("ID_DEPOSIT_SALE");
    const depositoMateriaPrimaId = await api.settings.get(
      "ID_DEPOSIT_RAW_MATERIAL"
    );
    const capital1 = await api.productos.getCapital(
      depositoProduccionId.data.Value
    );
    const capital2 = await api.productos.getCapital(
      depositoMateriaPrimaId.data.Value
    );

    const capitalTotal = capital1.data.Sum + capital2.data.Sum;
    this.setState({
      productos: request.data,
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
      agregarModalVisible:false,
    });
    this.actualizar();
  }

  async actualizar() {
     if (this.state.selector === "MATERIAPRIMA") {
      const depositoMateriaPrimaId = await api.settings.get(
        "ID_DEPOSIT_RAW_MATERIAL"
      );

      const capital2 = await api.productos.getCapital(
        depositoMateriaPrimaId.data.Value
      );
      const request = await api.productos.getMateriasPrimas();
      const capitalTotal = capital2.data.Sum;
      this.setState({
        productos: request.data,
        capital: capitalTotal,
      });
    } else if (this.state.selector === "PRODUCTOSTERMINADOS") {
      const depositoProduccionId = await api.settings.get("ID_DEPOSIT_SALE");

      const capital1 = await api.productos.getCapital(
        depositoProduccionId.data.Value
      );
      const request = await api.productos.getProductosTerminados();
      const capitalTotal = capital1.data.Sum;
      this.setState({
        productos: request.data,
        capital: capitalTotal,
      });
      this.setState({
        productos: request.data,
        capital: capitalTotal,
      });
    }
  }
  async mostrarProductosTerminados() {
    await this.setState({
      selector: "PRODUCTOSTERMINADOS",
      nombreSelector: "ProductosTerminados",
    });
    await this.actualizar();
  }
  async mostrarMateriaPrima() {
    await this.setState({
      selector: "MATERIAPRIMA",
      nombreSelector: "Materia Prima",
    });
    await this.actualizar();
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

  formato(locales, moneda, numero){
    var format = new Intl.NumberFormat(locales,{
      style: "currency",
      currency: moneda,
      minimumFractionDigits:0
    }).format(numero);
    return format;
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
        <AgregarModal
        visible={this.state.agregarModalVisible}
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
                      href="#materiaPrima"
                      onClick={() => this.mostrarMateriaPrima()}
                    >
                      Materia Prima
                    </a>
                    <a
                      className="dropdown-item"
                      href="#productosTerminados"
                      onClick={() => this.mostrarProductosTerminados()}
                    >
                      Productos Terminados
                    </a>
                  </div>
                </div>
                <button className="btn btn-primary"
                onClick={()=>this.setState({agregarModalVisible:true})}
                >Agregar Producto</button>
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
                <th scope="col">Stock</th>
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
                      {this.formato("es-PY","PYG",p.Cost)}
                    </td>
                    <td onClick={() => this.mostrarDetallesProducto(p)}>
                      {p.QuantityStock}
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
            <span className="form-control">{this.formato("es-PY","PYG",this.state.capital)}</span>
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

export default Stock;
