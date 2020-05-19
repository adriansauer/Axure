import React,{Component} from 'react';
import {connect} from 'react-redux';
/**importando acciones */
import {setSectionShow} from '../Redux/actions';
import AsideProducto from './Modulo Productos/AsideProducto.js';
import AsideVenta from './Modulo Ventas/AsideVenta.js';

import './style.css';
class Aside extends Component{


    render(){
        return (
            <div id="Section" className='Section'>
                {(() => {
                    switch(this.props.modulo[0]) {
                        case 1:return <AsideProducto/>
                        case 2:return <AsideVenta/>

                        default: return <AsideProducto/>    
                        
                    }

                })()}
            </div>
        )
    }
}
const mapStateToProps=state=>{
    return{
        codigo:state.sectionShow,
        modulo:state.modulo,
    }
}
const mapDispatchToProps=({
    setSectionShow,
})

export default connect(mapStateToProps,mapDispatchToProps)(Aside);