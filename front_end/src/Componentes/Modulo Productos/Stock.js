import React, { Component } from "react";
import "./styleMProductos.css";

import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import ThumbDownIcon from "@material-ui/icons/ThumbDown";
import { getProductos, deleteProducto } from "../../Redux/actions.js";
import { connect } from "react-redux";
class Stock extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nombreBtn: "Todos",
      total: 0
    };
  }
  

componentDidMount() {
    this.props.getProductos();
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
                    this.setState(state => ({ nombreBtn: "Todos" }))
                  }
                  className="dropdown-item"
                  href="#todos"
                >
                  Todos
                </p>
                <p
                  onClick={() =>
                    this.setState(state => ({ nombreBtn: "Materia prima" }))
                  }
                  className="dropdown-item"
                >
                  Materia prima
                </p>
                <p
                  onClick={() =>
                    this.setState(state => ({ nombreBtn: "En produccion" }))
                  }
                  className="dropdown-item"
                >
                  En produccion
                </p>
                <p
                  onClick={() =>
                    this.setState(state => ({
                      nombreBtn: "Productos terminados"
                    }))
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
              {(() => {
                if (this.props.productos !== []) {
                  

                  return this.props.productos.map(p => (
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
                  ));
                }
              })()}
         
            </tbody>
          </table>
        </div>
        <div className="StockFooter">
         
          Capital total:{this.state.total}</div>
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {
    productos: state.productos
  };
};
const mapDispatchToProps = {
  getProductos,
  deleteProducto
};
export default connect(mapStateToProps, mapDispatchToProps)(Stock);
