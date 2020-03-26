import React,{Component} from 'react';
import {connect} from 'react-redux';
/**importando acciones */
import {setSectionShow} from '../../Redux/actions';
import '../style.css';
class AsideProducto extends Component{


    render(){
        
        return(
<<<<<<< HEAD
            <div className="Aside btn-group-vertical col-md-2">
=======
            <div className="Aside col-md-2">
>>>>>>> master
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