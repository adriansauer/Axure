import React,{Component} from 'react';
import './styleMProductos.css';
class ProductosBaja extends Component{

    render(){
        return(
            <div className='productosBaja'>
                <div className='productosBajaCabecera'>
                       
                </div>
                <div className='productosBajaBody'>
                <table className="table table-hover table-dark">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Codigo</th>
      <th scope="col">Cantidad</th>
      <th scope="col">Fecha</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Monitor SONY</td>
      <td>2</td>
      <td>02/03/2020</td>
    </tr>
  </tbody>
</table>
                </div>
                <div className='productosBajaFooter'>
                       
                </div>
  
            </div>
        );
    }
}
export default ProductosBaja;