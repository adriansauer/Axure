import React, { Component } from "react";
import "./styleMProductos.css";
import { connect } from "react-redux";
import { ModalFooter, ModalBody, Modal, ModalHeader, Col,Container,Row } from "reactstrap";

class GenerarOrdenProduccion extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: this.props.productos_terminados,
      buscador: "",
      generarOrdenModalVisible:false,
      cantidad:'',
      productoId:0,
    };
  }
  render() {
    /*Modal generar una orden de producccion*/
    const generarOrdenModal = (
      <Modal isOpen={this.state.generarOrdenModalVisible} centered>
        <ModalHeader>Cantidad del producto a generar</ModalHeader>
        <ModalBody>
          {/**INPUT PARA INGRESAR LA CANTIDAD DE PRODUCTOS QUE SE QUIERE DAR DE BAJA*/}
          <input
            type="text"
            className="form-control"
            placeholder="Cantidad"
            value={this.state.cantidad}
            onChange={e=>{this.setState({cantidad:e.target.value})}}
          />
        </ModalBody>
        <ModalFooter>
          <button onClick={() => this.setState({ generarOrdenModalVisible: false })}>
            Generar Orden
          </button>
          <button onClick={() => this.setState({ generarOrdenModalVisible: false })}>
            Cancelar
          </button>
        </ModalFooter>
      </Modal>
    );

    return (
      <div className="generarOrdenProduccion">
        {generarOrdenModal}
        <div className="row">
          <div className="col-md-5"></div>
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
        <div className="row">
          <div className="col-md-3"></div>
          <div className="StockBody MateriaPima col-md-6">
            <table className="table table-hover table-dark">
              <thead className="tableHeader">
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Nombre</th>
                  <th scope="col">Descripcion</th>
                  <th scope="col">Costo</th>
                  <th scope="col">Codigo de barra</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {this.state.productos
                  .filter(
                    producto =>
                      producto.NameP.toLowerCase().indexOf(
                        this.state.buscador.toLowerCase()
                      ) !== -1
                  )
                  .map(p => (
                    <tr key={p.Id}
                    onClick={()=>this.setState({
                      productoId:p.Id,
                      generarOrdenModalVisible:true,
                    })}
                    >
                      <td>{p.Id}</td>
                      <td>{p.NameP}</td>
                      <td>{p.DescriptionP}</td>
                      <td>{p.Cost}</td>
                      <td>{p.Barcode}</td>
                    </tr>
                  ))}
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-md-8"></div>
          <div className="col-md-2"></div>
        </div>

        
      </div>
    );
  }
}
const mapStateToProps = state => {
  return {
    productos_terminados: state.productos_terminados
  };
};
const mapDispatchToProps = {};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(GenerarOrdenProduccion);
