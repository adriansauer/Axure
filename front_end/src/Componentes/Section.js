import React,{Component} from 'react';
import './style.css';
import {connect} from 'react-redux';
import {getProductos,postProductos} from '../Redux/actions.js';

class Section extends Component{
 
    render(){ 

        return(
           
            <div className='Section col-md-8'>
                
            </div>
        );

    }
}
const mapStateToProps=state=>{
    return {
        productos:state.productos,
    };
}
const mapDispatchToProps=({
    getProductos,
    postProductos,
})
export default connect(mapStateToProps,mapDispatchToProps)(Section);