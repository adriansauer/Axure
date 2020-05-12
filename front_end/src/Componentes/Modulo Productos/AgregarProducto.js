import React, { Component } from "react";
import "./styleMProductos.css";
import api from "../../Axios/Api.js";
import Notificacion,{notify} from "../Notificacion.js";
class AgregarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombretxt: "",
      descripciontxt: "",
      costotxt: "",
      codigoBarratxt: "",
      cantidadMintxt: "",
      tipoProducto: 1,
      buscador:"",
      componentesSeleccionados: [],
      listarMateriaPrimaVisible: false,
    };
  }
  async componentDidMount() {
    const request =await api.productos.getProductosDeCompra();
  }
  seleccionarComponente(producto) {
    this.setState({
      ...this.state,
      componentesSeleccionados: this.state.componentesSeleccionados.concat({
        Name: producto.Name,
        Id: producto.Id,
        Description: producto.Description,
        Cantidad: "1",
      }),
    });
    this.setState({ buscador: "" });
  }
  verificarCampos() {
    if (
      this.state.nombretxt !== "" &&
      this.state.descripciontxt !== "" &&
      this.state.costotxt !== "" &&
      this.state.codigoBarratxt !== ""
    ) {
      return true;
    }
    return false;
  }
  async enviarProducto() {
   const request=await api.productos.create({
      Name: this.state.nombretxt,
      ProductTypeId: this.state.tipoProducto,
      Description: this.state.descripciontxt,
      Cost: this.state.costotxt,
      QuantityMin: this.state.cantidadMintxt,
      Barcode: this.state.codigoBarratxt,
      ListComponents: this.state.componentesSeleccionados,
    });
    if(request.status===200){
      notify("Producto creado exitosamente!","success");
    }else{
      notify("No se pudo crear el producto!","danger");
    }
  }
 
  handleSubmit = (event) => {
    event.preventDefault();

    if (this.verificarCampos()) {
      this.enviarProducto();
      this.setState({
        nombretxt: "",
        descripciontxt: "",
        costotxt: "",
        codigoBarratxt: "",
        cantidadMintxt: "",
        tipoProducto: this.state.tipoProducto,
        componentes: this.state.componentes,
      });
    } else {
      notify("Rellene todos los campos!","warning");
    }
  };

  render() {
    return (
      <div className="agregarProducto">
        <Notificacion/>
        <form onSubmit={this.handleSubmit}>
          <div className="form-group row bg-title">
            <label className="m-auto title-label">Agregar Producto</label>
          </div>
          <div className="form-group row mb-2">
            <label htmlFor="" className="">
              Nombre del Producto
            </label>
            <input
              type="text"
              className="form-control"
              placeholder="Nombre del Producto"
              value={this.state.nombretxt}
              onChange={(e) => {
                this.setState({ nombretxt: e.target.value });
              }}
            />
          </div>
          <div className="form-group row mb-3">
            <label htmlFor="" className="">
              Descripcion del Producto
            </label>
            <textarea
              className="form-control"
              placeholder="Descripcion del producto"
              value={this.state.descripciontxt}
              onChange={(e) => {
                this.setState({ descripciontxt: e.target.value });
              }}
              rows="3"
            ></textarea>
          </div>
          <div className="dropdown-divider"></div>
          <div className="form-group row mb-2">
            <label htmlFor="" className="">
              Costo{" "}
            </label>
            <input
              type="text"
              className="form-control"
              placeholder="Costo"
              value={this.state.costotxt}
              onChange={(e) => {
                this.setState({ costotxt: e.target.value });
              }}
            />
          </div>
          <div className="form-group row mb-2">
            <label htmlFor="" className="">
              Cantidad Minima
            </label>
            <input
              type="text"
              className="form-control"
              placeholder="Cantidad Minima"
              value={this.state.cantidadMintxt}
              onChange={(e) => {
                this.setState({ cantidadMintxt: e.target.value });
              }}
            />
          </div>
          <div className="form-group row mb-3">
            <label htmlFor="" className="">
              Codigo de Barra
            </label>
            <input
              type="text"
              className="form-control"
              placeholder="Codigo de barra"
              value={this.state.codigoBarratxt}
              onChange={(e) => {
                this.setState({ codigoBarratxt: e.target.value });
              }}
            />
          </div>
          <div className="dropdown-divider"></div>
          <div className="form-group row">
            <label>Tipo de Producto</label>
            <div className="form-group check-list mx-auto">
              <div className="form-check form-check-inline">
                <input
                  type="radio"
                  className="mr-1"
                  value="1"
                  checked={this.state.tipoProducto === 2}
                  onChange={(e) => {
                    this.setState({ tipoProducto: 2 });
                  }}
                />
                <label className="form-check-label mr-2" htmlFor="inlineRadio1">
                  Materia Prima
                </label>
              </div>
              <div className="form-check form-check-inline">
                <input
                  type="radio"
                  className="mr-1"
                  value="2"
                  checked={this.state.tipoProducto === 3}
                  onChange={(e) => {
                    this.setState({ tipoProducto: 3 });
                  }}
                />
                <label className="form-check-label mr-2" htmlFor="inlineRadio2">
                  Producto Terminado
                </label>
              </div>
              <div className="form-check form-check-inline">
                <input
                  type="radio"
                  className="mr-1"
                  value="3"
                  checked={this.state.tipoProducto === 1}
                  onChange={(e) => {
                    this.setState({ tipoProducto: 1 });
                  }}
                />
                <label className="form-check-label" htmlFor="inlineRadio3">
                  Ambos
                </label>
              </div>
            </div>
          </div>
          <div className="dropdown-divider"></div>
          <div className="form-group row mt-3">
            <button
              type="submit"
              className="btn btn-primary ml-auto"
              value="Crear Producto"
            >
              Crear Producto
            </button>
          </div>
        </form>

      </div>

    );
  }
}

export default AgregarProducto;
