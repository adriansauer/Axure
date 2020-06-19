import React, { Component } from "react";
import BuscarOrden from "./Auxiliares/BuscarOrden.js";

class Facturar extends Component {
  constructor(props){
    super(props);
    this.state={
      buscarVisible:true,
      crearFacturaVisible:false,
      facturaVisible:false,
    
    }
  }
  render() {
    return (
      <div className="Facturar">     
     
        <BuscarOrden/>
       
      </div>
    );
  }
}
export default Facturar;
