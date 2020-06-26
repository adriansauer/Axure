import React, { Component } from "react";
import "./style.css";
import { connect } from "react-redux";
/**importar componentes  */
<<<<<<< HEAD
import Stock from "./Modulo Productos/Stock";
import GenerarOrdenProduccion from "./Modulo Productos/GenerarOrdenProduccion";
import OrdenesProduccionProductos from "./Modulo Productos/OrdenesProduccionProductos";
import ProductosBaja from "./Modulo Productos/Movimientos";
import DarDeBaja from "./Modulo Productos/Ingreso_Egreso.js";
import PedidoVenta from "./Modulo Ventas/OrdenVenta.js";
import Clientes from "./Modulo Ventas/Clientes.js";
import Facturar from "./Modulo Ventas/Facturar.js";
import ListadoFacturas from "./Modulo Ventas/ListadoFacturas.js";
class Section extends Component {
  render() {
    return (
      <div id="Section" className="Section" style={{ height: "100%" }}>
        {(() => {
          switch (this.props.sectionShow[0]) {
            case 50:
              return <Stock />;
            case 52:
              return <GenerarOrdenProduccion />;
            case 53:
              return <OrdenesProduccionProductos />;
            case 54:
              return <ProductosBaja />;
            case 55:
              return <DarDeBaja />;
            case 60:
              return <PedidoVenta />;
            case 61:
              return <Clientes />;
            case 62:
              return <Facturar />;
              case 63:
                return <ListadoFacturas />;
            default:
              return <Stock />;
          }
        })()}
      </div>
    );
  }
=======
import Stock from './Modulo Productos/Stock';
import GenerarOrdenProduccion from './Modulo Productos/GenerarOrdenProduccion';
import OrdenesProduccionProductos from './Modulo Productos/OrdenesProduccionProductos';
import ProductosBaja from './Modulo Productos/Movimientos';
import DarDeBaja from './Modulo Productos/Ingreso_Egreso.js';
import PedidoVenta from './Modulo Ventas/OrdenVenta.js';
import Clientes from './Modulo Ventas/Clientes.js';
import ComprasP from './Modulo Compras/ComprasP.js';
class Section extends Component{
 
    render(){ 
        
        return (
            <div id="Section" className='Section'>
                {(() => {
                    switch(this.props.sectionShow[0]) {
                        case 50:return <Stock/>
                        case 52:return <GenerarOrdenProduccion/>
                        case 53:return <OrdenesProduccionProductos/>
                        case 54:return <ProductosBaja/>
                        case 55:return <DarDeBaja/>
                        case 60:return <PedidoVenta/>
                        case 61:return <Clientes/>
                        case 70:return <ComprasP/>
                        default: return <Stock/>
                        
                    }

                })()}
            </div>
        )

    }
>>>>>>> master
}
const mapStateToProps = (state) => {
  return {
    sectionShow: state.sectionShow,
    modulo: state.modulo,
  };
};
const mapDispatchToProps = {};
export default connect(mapStateToProps, mapDispatchToProps)(Section);
