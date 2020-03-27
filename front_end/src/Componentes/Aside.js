import React,{Component} from 'react';
import {connect} from 'react-redux';
/**importando acciones */
import {setSectionShow} from '../Redux/actions';
import AsideProducto from './Modulo Productos/AsideProducto.js';
import './style.css';
class Aside extends Component{


    render(){
        
        return(
<<<<<<< HEAD
<<<<<<< HEAD
            <div className="Aside btn-group-vertical col-md-2">
                    <AsideProducto/>
          </div>
=======
            <AsideProducto/>
>>>>>>> cce357a7a776ed6ebb792a9b1eaa8693dc784296
=======

            <AsideProducto/>      

>>>>>>> 229a3ba99eaca9ff701551b287813d5ae20e8279
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