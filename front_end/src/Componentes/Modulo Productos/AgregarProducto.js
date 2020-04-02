import React, { Component } from "react";
import "./styleMProductos.css";
import { connect } from "react-redux";
import { createProducto } from "../../Redux/actions.js";
class AgregarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      /**obteniendo los datos del formulario de agregar productos */
      nombretxt: "",
      descripciontxt: "",
      costotxt: "",
      codigoBarratxt: "",
      cantidadMintxt: "",
      tipoProducto: 1,
      /**todas las materias primas que tienen cantidad mayor a 0 */
      componentes: []
    };
  }
  componentDidMount() {
    /**Agrega todas las materias primas al estado componentes */
    this.agregarComponentes();
  }
  /**Verifica si todos los campos de han rellenado */
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
  /**enviar el producto a la api */
  enviarProducto() {
    if (this.verificarCampos()) {
      this.props.createProducto({
        NameP: this.state.nombretxt,
        IdProductType: this.state.tipoProducto,
        DescriptionP: this.state.descripciontxt,
        Cost: this.state.costotxt,
        QuantityMin: this.state.cantidadMintxt,
        Barcode: this.state.codigoBarratxt,
        listaComponentes: this.state.componentes
      });
    } else {
      console.log("Rellene todos los campos");
    }
  }
  /**agrega el producto, y setea todos los estados a null */
  handleSubmit = event => {
    event.preventDefault();
    this.enviarProducto();
    this.setState({
      nombretxt: "",
      descripciontxt: "",
      costotxt: "",
      codigoBarratxt: "",
      cantidadMintxt: "",
      tipoProducto: 1,
      componentes: this.state.componentes.filter(c => c.Cantidad !== 0)
    });
  };
  /**Agrega todas las materias primas al estado componentes */

  agregarComponentes() {
  
}
  render() {
    /**COMPONENTE QUE LISTA LAS MATERIAS PRIMAS PARA AGREGAR UN PRODUCTO TERMINADO */
    const listaMateriaPrima = (
      <div className="StockBody MateriaPima row">
        <table className="table table-hover table-dark">
          <thead className="tableHeader">
            <tr>
              <th scope="col">#</th>
              <th scope="col">Nombre</th>
              <th scope="col">Descripcion</th>
              <th scope="col">Cantidad</th>
            </tr>
          </thead>
          <tbody className="tableBody">
            {this.state.componentes.map(p => (
              <tr key={p.Id}>
                <td>{p.Id}</td>
                <td>{p.NameP}</td>
                <td>{p.DescriptionP}</td>

                {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                <td>
                  <input
                    type="text"
                    className="form-control"
                    placeholder="Cantidad"
                    value={p.Cantidad}
                    onClick={e => {
                      console.log("hola");
                    }}
                  />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );

    return (
      <div className="agregarProducto">
        <form onSubmit={this.handleSubmit}>
          <div className="form-row">
            <div className="col-md-6">
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
            <div className="col-md-6">
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
            </div>
            <div className="col-md-6">
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
            </div>
            <div className="col-md-6">
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
            </div>
            <div className="col-md-6">
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
            </div>
            <div className="col-md-12">
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
              {/**BOTON PARA AGREGAR PRODUCTO*/}
              <input
                className="btn btn-primary"
                type="submit"
                value="Agregar"
              />
            </div>
            <div className="col-md-12">
              {/** EN EL CASO DE QUE SEA UN PRODUCTO TERMINADO, SE DESPLAZA UN COMPONENTE PARA CARGAR SUS MATERIAS PRIMAS */}
              {this.state.tipoProducto === 2
                ? /**SI ES UN PRODUCTO TERMINIADO DESPLAZAR LA LISTA DE MATERIA PRIMA */
                  listaMateriaPrima
                : /**EN CASO CONTRARIO NO HACER NADA */
                  null}
            </div>
          </div>
        </form>
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {
    materiaPrima: state.materias_primas
  };
};
const mapDispatchToProps = {
  createProducto
};
export default connect(mapStateToProps, mapDispatchToProps)(AgregarProducto);
