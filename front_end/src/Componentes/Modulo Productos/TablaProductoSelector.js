import React,{Component} from 'react';
import './styleMProductos.css'
import VisibilityIcon from "@material-ui/icons/Visibility";
import DeleteIcon from "@material-ui/icons/Delete";
import DetallesModal from "./Modales/ProductoDetalles.js";
class TablaProductoSelector extends Component{
    
    constructor(props){
        super(props);
        this.state={
            detallesModalVisible: false,
      productoSeleccionado: {
        Id: "",
        Name: "",
        Description: "",
        Cost: "",
        ProductType: {
          Id: "",
        },
        Barcode: "",
        QuantityMin: "",

      },
        }
       
    } 
    
    ocultarModal(){
      this.setState({
        detallesModalVisible:false,
      })
    }
    render(){
        const productos=this.props.productos;
     
        return(
            <div className="row p-3">
                <DetallesModal
                producto={this.state.productoSeleccionado}
                visible={this.state.detallesModalVisible}
                ocultar={this.ocultarModal.bind(this)}
                />
            <table className="table table-hover table">
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