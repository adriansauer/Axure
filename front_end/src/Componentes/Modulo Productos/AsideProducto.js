import React,{Component} from 'react';
import {connect} from 'react-redux';
/**importando acciones */
import {setSectionShow} from '../../Redux/actions';
import '../style.css';
class AsideProducto extends Component{


    render(){
        
        return(
<<<<<<< HEAD
<<<<<<< HEAD
            <div className="Aside col-md-2">
=======
            <div className="Aside btn-group-vertical col-md-2">
>>>>>>> cce357a7a776ed6ebb792a9b1eaa8693dc784296
=======

            <div className="Aside btn-group-vertical col-md-2">

>>>>>>> 229a3ba99eaca9ff701551b287813d5ae20e8279
  <button onClick={()=> this.props.setSectionShow(50)} type="button" className="btn btn-secondary btnAsideP">Stock</button>
  <button onClick={()=> this.props.setSectionShow(51)} type="button" className="btn btn-secondary btnAsideP">Agregar Producto</button>
  <button onClick={()=> this.props.setSectionShow(52)} type="button" className="btn btn-secondary btnAsideP">Generar orden de produccion</button>
  <button onClick={()=> this.props.setSectionShow(53)} type="button" className="btn btn-secondary btnAsideP">Ordenes de produccion</button>
  <button onClick={()=> this.props.setSectionShow(54)} type="button" className="btn btn-secondary btnAsideP1">Productos dados de baja</button>

          </div>
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

export default connect(mapStateToProps,mapDispatchToProps)(AsideProducto);