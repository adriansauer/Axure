import React,{Component} from 'react';

import './style.css';

class Menu extends Component{
    constructor(props){
        super(props);
        this.state={}
    }

    render(){
      
        return(
         
          <div className="Menu btn-group-vertical col-md-2">
  <button type="button" className="btn btn-secondary">Productos</button>
  <button type="button" className="btn btn-secondary">Venta</button>
  <button type="button" className="btn btn-secondary">Compra</button>
  <button type="button" className="btn btn-secondary">Contabilidad</button>
          </div>
          
        );
    }
}
export default Menu;