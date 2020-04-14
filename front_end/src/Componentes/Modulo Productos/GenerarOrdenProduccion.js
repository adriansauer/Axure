import React,{Component} from 'react';
import './styleMProductos.css';
import  {connect} from 'react-redux';
class GenerarOrdenProduccion extends Component{
    constructor(props){
        super(props);
        this.state={
            productos:this.props.productos_terminados,
            buscador:'',
        }
    }
    render(){
        const productos  = this.state.productos.map(p => {
      
            return {
              NameP: p.NameP,
              DescriptionP: p.DescriptionP,
              Id: p.Id,
              Cantidad: '0'
            };
          });
        return(
            <div className='generarOrdenProduccion'>
                <div className="row">

               
                <div className="col-md-3">
                <input
              className="form-control form-control-sm  buscador"
              type="text"
              placeholder="Search"
              aria-label="Search"
              value={this.state.buscador}
              onChange={e => {
                this.setState({ buscador: e.target.value });
              }}
            />
                </div>
                <div className="StockBody MateriaPima col-md-6">
            <table className="table table-hover table-dark">
              <thead className="tableHeader">
                <tr>
                 
                  <th scope="col">#</th>
                  <th scope="col">Nombre</th>
                  <th scope="col">Descripcion</th>
                  <th scope="col">Cantidad</th>
                </tr>
              </thead>
              <tbody className="tableBody">
                {productos.filter(
                  producto =>
                    producto.NameP.toLowerCase().indexOf(
                      this.state.buscador.toLowerCase()
                    ) !== -1
                ).map(p => (
                  <tr key={p.Id}>
                    <td>{p.Id}</td>
                    <td>{p.NameP}</td>
                    <td>{p.DescriptionP}</td>

                    {/**obtiene la cantidad de este componente que se utilizara para el producto terminado */}
                    <td>
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Cantidad"
                        onChange={e => (p.Cantidad = e.target.value)}
                      />
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          </div>
          <div className="row">
              <div className="col-md-8">

              </div>
                    <div className="col-md-2">
                    <button>Generar Orden</button>
                    </div>
          </div>
            </div>
        );
    }
}
const mapStateToProps = state => {
    return {
      productos_terminados: state.productos_terminados
    };
  };
  const mapDispatchToProps = {
   
  };

export default connect(mapStateToProps,mapDispatchToProps)(GenerarOrdenProduccion);