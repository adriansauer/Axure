import React, { Component } from "react";
import { ModalFooter, ModalBody, Modal, ModalHeader } from "reactstrap";
import Notificacion, { notify } from "../../Notificacion.js";
import api from ".././../../Axios/Api.js";
import CrearFacturaModal from "./CrearFactura.js";
/**
 * Propiedades
 * visible: true || false
 * ocultar()
 * orden
 */

class FacturarModal extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productos: [],
      productosSeleccionados: null,
      detalles: [],
      crearFacturaModalVisible:false,
      cliente:{
        Name:"",
        Address:"",
        RUC:"",
      },
    };
  }
  async componentDidMount() {
    try {
      const productos = await api.productos.getProductosDeVenta();
      this.setState({ productos: productos.data });
    } catch (error) {
      notify("Error al intentar conectar con la base de datos", "danger");
    }
  }
  componentWillReceiveProps(){
    if (this.props.orden !== null) {
      this.setState({
        detalles: this.props.orden.ListDetails.map((d) => {
          return {
            Id: d.ProductId,
            Quantity: d.Quantity,
            QuantityPending: d.QuantityPending,
            ProductId: d.ProductId,
            IVAid:this.state.productos
            .filter((p) => p.Id === d.ProductId)
            .map((p) => p.IVAid)[0],
            Cost:this.state.productos
            .filter((p) => p.Id === d.ProductId)
            .map((p) => p.Cost)[0],
            Cantidad: "0",
            ProductName: this.state.productos
              .filter((p) => p.Id === d.ProductId)
              .map((p) => p.Name)[0],
            ProductDescription: this.state.productos
              .filter((p) => p.Id === d.ProductId)
              .map((p) => p.Description)[0],
          };
        }),
      });
    }
  }
  modificarCantidad(e,d){
    const arreglo=this.state.detalles;
    arreglo[arreglo.indexOf(d)]={
      
        Id: d.ProductId,
        Quantity: d.Quantity,
        QuantityPending: d.QuantityPending,
        ProductId: d.ProductId,
        IVAid:d.IVAid,
        Cost:d.Cost,
        Cantidad: e.target.value,
        ProductName: this.state.productos
          .filter((p) => p.Id === d.ProductId)
          .map((p) => p.Name)[0],
        ProductDescription: this.state.productos
          .filter((p) => p.Id === d.ProductId)
          .map((p) => p.Description)[0],
     
    }
    this.setState({
      detalles: arreglo
    });
  }
  validar(){
    const detalles=this.state.detalles.map(p=>{
      if((p.Quantity - p.QuantityPending)>=p.Cantidad){
        return true;
      }else{
        return false;
      }
    })
    const detalles2=this.state.detalles.map(p=>{
      if(p.Cantidad!=="0"){
        return true;
      }else{
        return false;
      }
    })
    if(detalles.indexOf(false)===-1){
if(detalles2.indexOf(true)>-1){
 return true
}else{
  notify("No ha seleccionado ningun producto","warning");
  return false;
}
     
    }else{
      notify("Ha sobrepasado la cantidad de la orden de venta","warning");
      return false;
    }
    
  }
  ocultarModales(){
    this.setState({crearFacturaModalVisible:false})
  }
 async  facturar() {
    if(this.validar()){
       const productos=await this.state.detalles.filter(p=>p.Cantidad!=="0");
       console.log(productos);
      const clientes=await api.clientes.get();
      await this.setState({productosSeleccionados:productos,cliente:clientes.data.filter(c=>c.Id===this.props.orden.ClientId).map(c=>c)[0]})
      this.props.ocultar();
      this.setState({crearFacturaModalVisible:true});
    }
  }
  render() {
    return (
      <div>
       <CrearFacturaModal
       ocultar={this.ocultarModales.bind(this)}
       visible={this.state.crearFacturaModalVisible}
       productos={this.state.productosSeleccionados}
       orden={this.props.orden}
       cliente={this.state.cliente}
       />
<Notificacion />
        <Modal isOpen={this.props.visible} centered> 
        
          <ModalHeader>Facturar</ModalHeader>
          <ModalBody>
            <div className="row"></div>
            <div className="row">
              <table
                className="table table-hover table"
                style={{ marginTop: "3%" }}
              >
                <thead className="tableHeader">
                  <tr>
                    <th scope="col">Producto</th>
                    <th scope="col">Cantidad total</th>
                    <th scope="col">Cantidad pendiente</th>
                    <th scope="col">Cantidad a facturar</th>
                  </tr>
                </thead>
                <tbody className="tableBody">
                  {this.props.orden !== null
                    ? this.state.detalles.map((p) => (
                        <tr key={p.Id}>
                          <td>
                            {p.ProductName} {p.ProductDescription}
                          </td>
                          <td>{p.Quantity}</td>
                          <td>{p.Quantity - p.QuantityPending}</td>
                          <td>
                            <input
                              type="text"
                              className="form-control"
                              value={p.Cantidad}
                              onChange={(e)=>this.modificarCantidad(e,p)}
                              placeholder="Cantidad a facturar"
                            />
                          </td>
                        </tr>
                      ))
                    : null}
                </tbody>
              </table>
            </div>
          </ModalBody>
          <ModalFooter>
            <button onClick={() => this.facturar()}>Facturar</button>
            <button className="exit" onClick={() => this.props.ocultar()}>
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}
export default FacturarModal;
