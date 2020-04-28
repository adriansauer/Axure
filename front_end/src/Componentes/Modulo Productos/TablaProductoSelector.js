import React,{Component} from 'react';
import './styleMProductos.css'
import VisibilityIcon from "@material-ui/icons/Visibility";
import DeleteIcon from "@material-ui/icons/Delete";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";

class TablaProductoSelector extends Component{
    
    constructor(props){
        super(props);
        this.state={
            detallesModalVisible: false,
      productoSeleccionado: {
        Name: "",
        Description: "",
        Cost: "",
        Barcode: "",
        QuantityMin: "",
      },
        }
       
    } 
    
    
    render(){
        const productos=this.props.productos;
            /**Modal que permite ver los detalles de un producto seleccionado */
    const detallesModal = (
        <Modal isOpen={this.state.detallesModalVisible} centered>
          <ModalHeader>Detalles del Producto</ModalHeader>
          <ModalBody>
            <b> Nombre:</b> {this.state.productoSeleccionado.Name}
            <br />
            <b>Descripcion:</b> {this.state.productoSeleccionado.Description}
            <br />
            <b>Codigo de Barra:</b> {this.state.productoSeleccionado.Barcode}
            <br />
            <textarea className="form-control detalles" rows="3"></textarea>
          </ModalBody>
          <ModalFooter>
            <button
              onClick={() => this.setState({ detallesModalVisible: false })}
            >
              Cerrar
            </button>
          </ModalFooter>
        </Modal>
      );
        return(
            <div className="row">
                 {detallesModal}
            <table className="table table-hover table" style={{ marginTop: 50 }}>
              <thead className="tableHeader">
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Nombre</th>
                  <th scope="col">Descripcion</th>
                  <th scope="col">Codigo de barra</th>
                  <th scope="col">Cantidad</th>
                  <th scope="col">Acciones</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {productos.map((p) => (
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
                          const arreglo = productos;
                          arreglo[arreglo.indexOf(p)] = {
                            Name: p.Name,
                            Id: p.Id,
                            Description: p.Description,
                            Barcode: p.Barcode,
                            Cantidad: e.target.value,
                          };
                          this.setState({
                            productos: arreglo,
                          });
                        }}
                      />
                    </td>
                    {/**Boton para sacar de la lista el producto */}
                    <td>
                      <VisibilityIcon
                        onClick={() =>
                          this.setState({
                            productoSeleccionado: p,
                            detallesModalVisible: true,
                          })
                        }
                      />
                      <DeleteIcon onClick={() => this.props.delete(p.Id)} />
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        );
    }
}

export default TablaProductoSelector;