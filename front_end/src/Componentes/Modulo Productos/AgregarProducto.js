import React, { Component } from "react";
import "./styleMProductos.css";
import {connect} from 'react-redux';
import ArrowUpwardIcon from "@material-ui/icons/ArrowUpward";
import ArrowDownwardIcon from "@material-ui/icons/ArrowDownward";
import {createProducto} from '../../Redux/actions.js';
class AgregarProducto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombretxt: "",
      descripciontxt: "",
      costotxt: 0,
      codigoBarratxt: "",
      cantidadMin: 0
    };
  }
  
  aumentarCantidadMinima() {
    this.setState({ cantidadMin: this.state.cantidadMin + 1 });
  }
  disminuirCantidadMinima() {
    if (this.state.cantidadMin > 0) {
      this.setState({ cantidadMin: this.state.cantidadMin - 1 });
    }
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
  enviarProducto(){
      if(this.verificarCampos()){
         
          this.props.createProducto({
          'NombreP':this.state.nombretxt,
          'DescriprionP':this.state.descripciontxt,
          'Cost':this.state.costotxt,
          'QuantityMin':this.state.cantidadMin,
          'Barcode':this.state.codigoBarratxt
      });
      }else{
          console.log('Rellene todos los campos');
      }
      
  }
  handleSubmit = event => {
    event.preventDefault();
    this.enviarProducto();
  }
  render() {
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
              <label>Cantidad minima:{this.state.cantidadMin}</label>
              {/**ICONOS PARA AUMENTAR Y DISMINUIR LA CANTIDAD MINIMA*/}
              <ArrowUpwardIcon
                onClick={() => this.aumentarCantidadMinima()}
                className="icono"
              />
              <ArrowDownwardIcon
                onClick={() => this.disminuirCantidadMinima()}
                className="icono"
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
              {/**BOTON PARA AGREGAR PRODUCTO*/}
              <input className="btn btn-primary" type="submit" value="Agregar"/>
            </div>
          </div>
        </form>
      </div>
    );
  }
}
const mapStateToProps=state=>{
    return{

    }
}
const mapDispatchToProps={
    createProducto,
}
export default connect(mapStateToProps,mapDispatchToProps)(AgregarProducto);
