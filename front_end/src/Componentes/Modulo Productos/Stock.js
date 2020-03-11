import React,{Component} from 'react';
import './styleMProductos.css';

import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import ThumbDownIcon from '@material-ui/icons/ThumbDown';
import {getProductos} from '../../Redux/actions.js';
import {connect} from 'react-redux';
class Stock extends Component{
constructor(props){
    super(props);
    this.state={
        nombreBtn:'Todos',
       
            
    }
  
    }
    componentDidMount(){
        this.props.getProductos();
       
    }
    
    render(){
     
        return(
            <div className='stock'>
                <div className='StockCabecera row '>
                     <div className='col-md-3'>

                    </div>
                        <div className='col-md-3'>
                            
                                 <div className="dropdown seleccionador">
                                        <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                             {this.state.nombreBtn}
                                        </button>
                                    <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                         <p onClick={()=>this.setState(state=>({nombreBtn:'Todos'}))} className="dropdown-item" href='#todos' >Todos</p>
                                         <p onClick={()=>this.setState(state=>({nombreBtn:'Materia prima'}))}  className="dropdown-item" >Materia prima</p>
                                         <p onClick={()=>this.setState(state=>({nombreBtn:'En produccion'}))}  className="dropdown-item"  >En produccion</p>
                                         <p onClick={()=>this.setState(state=>({nombreBtn:'Productos terminados'}))}  className="dropdown-item" >Productos terminados</p>
                                    </div>
                                </div>
                            
                             
                             </div>
                            <div className='col-md-4'>
                                     <input className="form-control form-control-sm  buscador" type="text" placeholder="Search"aria-label="Search"/>
                            </div>
                                       
                                    
                       
                         
                    </div>
                    <div className='StockBody'>
                        
                    <table className="table table-hover table-dark">
  <thead className='tableHeader' >
    <tr>
     
      <th scope="col">Nombre</th>
      <th scope="col">Descripcion</th>
      <th scope="col">Costo</th>
      <th scope="col">Cantidad Minima</th>
      <th scope="col">Codigo de barra</th>
      <th scope="col"></th>
      
     
    </tr>
  </thead>
  <tbody className='tableBody'>
           
            {
              
              (this.props.productos !==[]) ? 
              this.props.productos.map(p=>
         
                <tr >
                  
                    <td>{p.NameP}</td>
                    <td>{p.DescriprionP}</td>
                    <td>{p.Cost}</td>
                    <td>{p.QuantityMin}</td>
                    <td>{p.Barcode}</td>
                    <td><EditIcon className='icono'/><DeleteIcon className='icono' /><ThumbDownIcon className='icono'/></td>
              
                </tr>
                
                ) 
              :
              null
              
            }      
                    
                
           
  </tbody>
</table>
                    </div>
                    <div className='StockFooter'>
                        Este es el Footer
                    </div>
            </div>
        );
    }
}
const mapStateToProps=state=>{
  return{
    productos:state.productos,
  }
}
const mapDispatchToProps={
getProductos,

}
export default connect(mapStateToProps,mapDispatchToProps)(Stock);