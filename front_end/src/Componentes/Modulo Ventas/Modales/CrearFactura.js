import React, { Component } from "react";
import { Modal, ModalFooter, ModalBody, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
/**
 * ocultar()
 * visible
 * productos{ProductId,Quantity}
 * cliente
 * orden
 */
class CrearFactura extends Component {
  constructor(props) {
    super(props);
    this.state = {
     

    };
  }


printDiv(nombreDiv) {
    const contenido= document.getElementById(nombreDiv).innerHTML;
    const contenidoOriginal= document.body.innerHTML;

    document.body.innerHTML = contenido;

    window.print();

    document.body.innerHTML = contenidoOriginal;
}
  render() {
    return (
      <div>
        <Notificacion />

        <Modal isOpen={this.props.visible} centered>
          <ModalBody>
            <div id="imprimir">

         
            <div className="row">
              <div className="col-md-6">
                <div className="col-md-12">
                  <label>Nombre o Razon social:{this.props.cliente.Name}</label>
                  <label>Direccion:{this.props.cliente.Address}</label>
                </div>
              </div>
              <div className="col-md-6">
                <div className="col-md-12">
                  <label>RUC:{this.props.cliente.RUC}</label>
                </div>
              </div>
            </div>
            <div className="row">
            <table
                className="table table-hover table"
                style={{ marginTop: "3%" }}
              >
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Cant</th>
                    <th scope="col">Concepto</th>
                    <th scope="col">Precio Unitario</th>
                    <th scope="col">Excentas</th>
                    <th scope="col">5%</th>
                    <th scope="col">10%</th>
                  </tr>
                </thead>
                <tbody className="tableBody">
                  {this.props.productos !== null
                    ? this.props.productos.map((p) => (
                        <tr key={p.Id}>  
                        <td>{p.Cantidad}</td>
                          <td>
                            {p.ProductName} {p.ProductDescription}
                          </td>
                        
                    <td>{p.Cost}</td>
                          
                        </tr>
                      ))
                    : null}
                </tbody>
              </table>

            </div>
            </div>
          </ModalBody>
          <ModalFooter>
            <button onClick={() => this.facturar()}>Facturar</button>
            <button onClick={() => this.printDiv("imprimir")}>Imprimir</button>
            <button className="exit" onClick={() => this.props.ocultar()}>
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}

export default CrearFactura;
