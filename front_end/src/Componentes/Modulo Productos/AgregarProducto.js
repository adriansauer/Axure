import React, { Component } from "react";
import "./styleMProductos.css";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
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
      componentes: [],

      /**estado visible de los modales */
      listarMateriaPrimaVisible: false
    };
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
  
    this.props.createProducto({
      Name: this.state.nombretxt,
      ProductTypeId: this.state.tipoProducto,
      Description: this.state.descripciontxt,
      Cost: this.state.costotxt,
      QuantityMin: this.state.cantidadMintxt,
      Barcode: this.state.codigoBarratxt,
      ListComponents: this.state.componentes
    });
  }
  /**Agrega todas las materias primas al estado componentes */

  agregarComponentes(materiaPrima) {
    this.setState({
      listarMateriaPrimaVisible: false,
      componentes: materiaPrima
        .filter(p => p.Cantidad !== "0")
        .map(p => {
          return {
            ProductComponentId: p.Id,
            Quantity: p.Cantidad
          };
        })
    });
  }
  /**agrega el producto, y setea todos los estados a null */
  handleSubmit = event => {
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
        componentes: this.state.componentes
      });
      
    } else {
      console.log("Rellene todos los campos");
    }
  };

  render() {
    /**guardo la materia prima
     * {
     * id
     * nombre
     * descripcion
     * cantidad(cuantos de estos componentes tendra el producto terminado)
     * }
     */
   const materiaPrima  = this.props.materiaPrima.map(p => 
      
     { return {
        Name: p.Name,
        Description: p.Description,
        Id: p.Id,
        Cantidad: '0'
      };}
    );
    /**COMPONENTE QUE LISTA LAS MATERIAS PRIMAS PARA AGREGAR UN PRODUCTO TERMINADO */
    const listarMateriaPrima = (
      <Modal isOpen={this.state.listarMateriaPrimaVisible} centered>
        <ModalHeader>Lista de componentes</ModalHeader>
        <ModalBody>
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
                {materiaPrima.map(p => (
                  <tr key={p.Id}>
                    <td>{p.Id}</td>
                    <td>{p.Name}</td>
                    <td>{p.Description}</td>

                    {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                    <td>
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Cantidad"
                        onChange={e => (p.Cantidad = e.target.value)}
                      />
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.agregarComponentes(materiaPrima)}>
            Listo!
          </button>
        </ModalFooter>
      </Modal>
    );

    return (
      <div className="agregarProducto">
        {/**Modales  */}
        {listarMateriaPrima}
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
                      checked={this.state.tipoProducto === 2}
                      onChange={e => {
                        this.setState({ tipoProducto: 2 });
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
                      checked={this.state.tipoProducto === 3}
                      onChange={e => {
                        this.setState({ tipoProducto: 3 });
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
                      checked={this.state.tipoProducto === 1}
                      onChange={e => {
                        this.setState({ tipoProducto: 1 });
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
                value="Crear Producto"
              />
            </div>

            {/** EN EL CASO DE QUE SEA UN PRODUCTO TERMINADO, SE DESPLAZA UN COMPONENTE PARA CARGAR SUS MATERIAS PRIMAS */}
            {this.state.tipoProducto === 3 ? (
              /**SI ES UN PRODUCTO TERMINIADO DESPLAZAR LA LISTA DE MATERIA PRIMA */
              <button
                type="button"
                className="btn btn-primary"
                onClick={() =>
                  this.setState({ listarMateriaPrimaVisible: true })
                }
              >
                Agregar Componentes
              </button>
            ) : /**EN CASO CONTRARIO NO HACER NADA */
            null}
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
