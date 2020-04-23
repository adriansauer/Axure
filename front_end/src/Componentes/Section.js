import React,{Component} from 'react';
import './style.css';
import {connect} from 'react-redux';
import {getProductos} from '../Redux/actions.js';
/**importar componentes  */
import Stock from './Modulo Productos/Stock';
import AgregarProducto from './Modulo Productos/AgregarProducto';
import GenerarOrdenProduccion from './Modulo Productos/GenerarOrdenProduccion';
import OrdenesProduccionProductos from './Modulo Productos/OrdenesProduccionProductos';
import ProductosBaja from './Modulo Productos/ProductosBaja';
class Section extends Component{
 
    render(){ 
        
        return (
            <div id="Section" className='Section'>
                {(() => {
                    switch(this.props.sectionShow[0]) {
                        case 50:return <Stock/>
                        case 51: return <AgregarProducto/>
                        case 52:return <GenerarOrdenProduccion/>
                        case 53:return <OrdenesProduccionProductos/>
                        case 54:return <ProductosBaja/>
                        default: return <Stock/>    
                        
                    }

                })()}
            </div>
        )

    }
}
const mapStateToProps=state=>{
    return {
        productos:state.productos,
        sectionShow:state.sectionShow,
        modulo:state.modulo,
    };
}
const mapDispatchToProps=({
    getProductos,
})
export default connect(mapStateToProps,mapDispatchToProps)(Section);