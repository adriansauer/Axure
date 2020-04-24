import React, { Component } from "react";
import "./styleMProductos.css";
import { connect } from "react-redux";

class GenerarOrdenProduccion extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: this.props.productos_terminados,
      buscador: "",
      productosSeleccionados: [],
    };
  }
  delete(id) {
    this.setState({
      productosSeleccionados: this.state.productosSeleccionados.filter(
        (producto) => producto.Id !== id
      ),
    });
  }
  seleccionarProducto(producto) {
    this.setState({
      ...this.state,
      productosSeleccionados: this.state.productosSeleccionados.concat({
        Name: producto.Name,
        Id: producto.Id,
        Description: producto.Description,
        Barcode: producto.Barcode,
        Cantidad: "1",
      }),
    });
    this.setState({ buscador: "" });
  }
  render() {
    return (
      <div className="generarOrdenProduccion ">
        <div className="row">
          <div className="col-md-4"></div>
          <div className="col-md-8">
            <h3>Generar Orden Produccion</h3>
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
          <input
                type="text"
                className="form-control"
                placeholder="Encargado"
                
                
              />
          </div>
          <div className="col-md-8"></div>
        </div>
        <div className="row" style={{"marginTop":20}}>
          <div className="StockBody MateriaPrima col-md-12">
            <table className="table table-hover table">
              <thead className="tableHeader">
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Nombre</th>
                  <th scope="col">Descripcion</th>
                  <th scope="col">Codigo de barra</th>
                  <th scope="col">Cantidad</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {this.state.productosSeleccionados.map((p) => (
                  <tr key={p.Id}>
                    <td>{p.Id}</td>
                    <td>{p.Name}</td>
                    <td>{p.Description}</td>
                    <td>{p.Barcode}</td>

                    {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                    <td>
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Cantidad"
                        value={p.Cantidad}
                        onChange={(e) => {
                          const arreglo = this.state.productosSeleccionados;
                          arreglo[arreglo.indexOf(p)] = {
                            Name: p.Name,
                            Id: p.Id,
                            Description: p.Description,
                            Barcode: p.Barcode,
                            Cantidad: e.target.value,
                          };
                          this.setState({
                            productosSeleccionados: arreglo,
                          });
                        }}
                      />
                    </td>
                    {/**Boton para sacar de la lista el producto */}
                    <td>
                      <button
                        onClick={() => {
                          this.delete(p.Id);
                        }}
                      >
                        Remover
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-md-4">
            <input
              className="form-control form-control-sm  buscador"
              type="text"
              id="id1"
              placeholder="Añadir producto"
            
              onChange={(e) => {
                this.setState({ buscador: e.target.value });
              }}
              value={this.state.buscador}
            />
          </div>
          <div className="col-md-4"></div>
          <div className="col-md-3">
            <button
            className="btn btn-primary"
              style={{ marginTop: 20 }}
              onClick={() => this.setState({ productosSeleccionados: [] })}
            >
              Guardar
            </button>
          </div>
        </div>
        <div className="row">
          <div className="StockBody MateriaPrima col-md-6">
            <table className="table table-hover table">
              <tbody className="tableBody">
                {this.state.buscador !== ""
                  ? this.state.productos
                      .filter(
                        (producto) =>
                          producto.Name.toLowerCase().indexOf(
                            this.state.buscador.toLowerCase()
                          ) !== -1
                      )
                      .filter(
                        (producto) =>
                          this.state.productosSeleccionados.find(
                            (e) => e.Id === producto.Id
                          ) === undefined
                      )
                      .map((p) => (
                        <tr
                          key={p.Id}
                          onClick={() => this.seleccionarProducto(p)}
                        >
                          <td>{p.Id}</td>
                          <td>{p.Name}</td>
                          <td>{p.Description}</td>
                          <td>{p.Cost}</td>
                          <td>{p.Barcode}</td>
                        </tr>
                      ))
                  : null}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    );
  }
}
const mapStateToProps = (state) => {
  return {
    productos_terminados: state.productos_terminados,
  };
};
const mapDispatchToProps = {};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(GenerarOrdenProduccion);
