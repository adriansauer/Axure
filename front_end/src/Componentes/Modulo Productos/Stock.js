import React, { Component } from "react";
import "./styleMProductos.css";

import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import ThumbDownIcon from "@material-ui/icons/ThumbDown";
import { getProductos, deleteProducto,getMateriasPrimas,getProductosTerminados,getProductosEnProduccion } from "../../Redux/actions.js";
import { connect } from "react-redux";
class Stock extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreBtn: "Todos",
      productos: this.props.productos,
      buscador:'',
    };
  }

  async componentDidMount() {
  await  this.props.getProductos();
  await  this.props.getMateriasPrimas();
  await  this.props.getProductosTerminados();
  await  this.props.getProductosEnProduccion();

    this.setState({productos:this.props.productos});
  }
 mostrarTodos(){
this.setState({nombreBtn:'Todos'});
this.setState({productos:this.props.productos});
 }
 mostrarMateriasPrimas(){
this.setState({nombreBtn:'Materia Prima'});
this.setState({productos:this.props.materias_primas});
 }
 mostrarProductosTerminados(){
this.setState({nombreBtn:'Terminados'});
this.setState({productos:this.props.productos_terminados});
 }
 mostrarProductosEnProduccion(){
  this.setState({nombreBtn:'En Produccion'});
  this.setState({productos:this.props.productos_en_produccion});
 }
 
 

  render() {
   
    return (
      <div className="stock">
        <div className="StockCabecera row ">
          <div className="col-md-3"></div>
          <div className="col-md-3">
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
                  onClick={() =>
                    this.mostrarTodos()
                  }
                  className="dropdown-item"
                  href="#todos"
                >
                  Todos
                </p>
                <p
                  onClick={() =>(
                    this.mostrarMateriasPrimas()
                   
                  )
                    
                  }
                  className="dropdown-item"
                >
                  Materia prima
                </p>
                <p
                  onClick={() =>
                    this.mostrarProductosEnProduccion()
                  }
                  className="dropdown-item"
                >
                  En produccion
                </p>
                <p
                  onClick={() =>
                    this.mostrarProductosTerminados()
                  }
                  className="dropdown-item"
                >
                  Productos terminados
                </p>
              </div>
            </div>
          </div>
          <div className="col-md-4">
            <input
              className="form-control form-control-sm  buscador"
              type="text"
              placeholder="Search"
              aria-label="Search"
              value={this.state.buscador}
              onChange={e=>{this.setState({buscador:e.target.value})}}
            
            />
          </div>
        </div>
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
            <tbody className="tableBody">
              {
                   this.state.productos.map(p => (
                    <tr key={p.Id}>
                      <td>{p.Id}</td>
                      <td>{p.NameP}</td>
                      <td>{p.DescriptionP}</td>
                      <td>{p.Cost}</td>
                      <td>{p.QuantityMin}</td>
                      <td>{p.Barcode}</td>
                      <td>
                        <EditIcon className="icono" />
                        <DeleteIcon
                          onClick={() => this.props.deleteProducto(p.Id)}
                          className="icono"
                        />
                        <ThumbDownIcon className="icono" />
                      </td>
                    </tr>
                  ))
              }
             
            </tbody>
          </table>
        </div>
        <div className="StockFooter"></div>
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {
    productos: state.productos,
    materias_primas: state.materias_primas,
    productos_terminados: state.productos_terminados,
    productos_en_produccion: state.productos_en_produccion
  };
};
const mapDispatchToProps = {
  getProductos,
  deleteProducto,
  getMateriasPrimas,
  getProductosTerminados,
  getProductosEnProduccion
};
export default connect(mapStateToProps, mapDispatchToProps)(Stock);
