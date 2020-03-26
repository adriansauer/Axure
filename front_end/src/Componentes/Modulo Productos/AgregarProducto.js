import React, { Component } from "react";
import "./styleMProductos.css";
import { connect } from "react-redux";
import { createProducto } from "../../Redux/actions.js";
class AgregarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombretxt: "",
      descripciontxt: "",
      costotxt: '',
      codigoBarratxt: "",
      cantidadMintxt: '',
      tipoProducto: 1
    };
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
  enviarProducto() {
    if (this.verificarCampos()) {
      this.props.createProducto({
        'NombreP': this.state.nombretxt,
        'DescriptionP': this.state.descripciontxt,
        'Cost': this.state.costotxt,
        'IdProductType': this.state.tipoProducto,
        'QuantityMin': this.state.cantidadMin,
        'Barcode': this.state.codigoBarratxt
      });
    } else {
      console.log("Rellene todos los campos");
    }
  }
  handleSubmit = event => {
    event.preventDefault();
    this.enviarProducto();
  };

  render() {
      /**COMPONENTE QUE LISTA LAS MATERIAS PRIMAS PARA AGREGAR UN PRODUCTO TERMINADO */
    const listaMateriaPrima = (
      <div>
        <h3>Agregue los productos necesarios</h3>
      </div>
    );

    return (
      <div className="agregarProducto">
        <form onSubmit={this.handleSubmit}>
          <div className="form-row">
            <div className="col">
              {/**NOMBRE DEL PRODUCTO*/}
              <input
                type="text"
                className="form-control"
                placeholder="Nombre del Producto"
                value={this.state.nombretxt}
                onChange={e => {
                  this.setState({ nombretxt: e.target.value });
                }}
              />
            </div>
            <div className="col">
              {/**DESCRIPCION DEL PRODUCTO*/}
              <input
                type="text"
                className="form-control"
                placeholder="Descripcion del producto"
                value={this.state.descripciontxt}
                onChange={e => {
                  this.setState({ descripciontxt: e.target.value });
                }}
              />
              {/**COSTO DEL PRODUCTO*/}
              <input
                type="text"
                className="form-control"
                placeholder="Costo"
                value={this.state.costotxt}
                onChange={e => {
                  this.setState({ costotxt: e.target.value });
                }}
              />
              {/**CANTIDAD MINIMA DEL PRODUCTO*/}
              <input
                type="text"
                className="form-control"
                placeholder="Cantidad Minima"
                value={this.state.cantidadMintxt}
                onChange={e => {
                  this.setState({ cantidadMintxt: e.target.value });
                }}
              />
              {/**CODIGO DE BARRA DEL PRODUCTO*/}
              <input
                type="text"
                className="form-control"
                placeholder="Codigo de barra"
                value={this.state.codigoBarratxt}
                onChange={e => {
                  this.setState({ codigoBarratxt: e.target.value });
                }}
              />
              {/**TIPO DEL PRODUCTO, -MATERIA PRIMA O -PRODUCTO TERMINADO O AMBOS */}
              <div>
                <div className="radio">
                  <label>
                    <input
                      type="radio"
                      value="1"
                      checked={this.state.tipoProducto === 1}
                      onChange={e => {
                        this.setState({ tipoProducto: 1 });
                      }}
                    />
                    Materia Prima
                  </label>
                </div>
                <div className="radio">
                  <label>
                    <input
                      type="radio"
                      value="2"
                      checked={this.state.tipoProducto === 2}
                      onChange={e => {
                        this.setState({ tipoProducto: 2 });
                      }}
                    />
                    Producto Terminado
                  </label>
                </div>
                <div className="radio">
                  <label>
                    <input
                      type="radio"
                      value="3"
                      checked={this.state.tipoProducto === 3}
                      onChange={e => {
                        this.setState({ tipoProducto: 3 });
                      }}
                    />
                    Ambos
                  </label>
                </div>
              </div>
              {/** EN EL CASO DE QUE SEA UN PRODUCTO TERMINADO, SE DESPLAZA UN COMPONENTE PARA CARGAR SUS MATERIAS PRIMAS */}
              {this.state.tipoProducto === 2 ? (
                /**SI ES UN PRODUCTO TERMINIADO DESPLAZAR LA LISTA DE MATERIA PRIMA */
                listaMateriaPrima
              ) : /**EN CASO CONTRARIO NO HACER NADA */
              null}
              {/**BOTON PARA AGREGAR PRODUCTO*/}
              <input
                className="btn btn-primary"
                type="submit"
                value="Agregar"
                onClick={()=>this.enviarProducto()}
              />
            </div>
          </div>
        </form>
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {};
};
const mapDispatchToProps = {
  createProducto
};
export default connect(mapStateToProps, mapDispatchToProps)(AgregarProducto);
