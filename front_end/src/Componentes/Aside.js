import React,{Component} from 'react';

import './style.css';
class Aside extends Component{
    constructor(props){
        super(props);
        this.state={}
    }

    render(){
        return(
            <div className="Aside btn-group-vertical col-md-2">
  <button type="button" className="btn btn-secondary">Stock</button>
  <button type="button" className="btn btn-secondary">Agregar Producto</button>
  <button type="button" className="btn btn-secondary">Generar orden de produccion</button>
  <button type="button" className="btn btn-secondary">Dar de baja</button>
  <button type="button" className="btn btn-secondary">Ordenes de productos</button>
  <button type="button" className="btn btn-secondary">Productos dados de baja</button>

          </div>
        );
    }
}

export default Aside;