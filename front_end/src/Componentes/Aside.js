import React,{Component} from 'react';
import {connect} from 'react-redux';
/**importando acciones */
import {setSectionShow} from '../Redux/actions';
import AsideProducto from './Modulo Productos/AsideProducto.js';
import './style.css';
import AsideProducto from './Modulo Productos/AsideProducto.js';
class Aside extends Component{


    render(){
        
        return(
<<<<<<< HEAD
            <AsideProducto/>
=======
            <div className="Aside btn-group-vertical col-md-2">
                    <AsideProducto/>
          </div>
>>>>>>> master
        );
    }
}
const mapStateToProps=state=>{
    return{
        codigo:state.sectionShow,
    }
}
const mapDispatchToProps=({
    setSectionShow,
})

export default connect(mapStateToProps,mapDispatchToProps)(Aside);