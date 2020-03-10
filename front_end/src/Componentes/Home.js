import React,{Component} from 'react';
import AttachMoneyIcon from '@material-ui/icons/AttachMoney';
import ArrowUpwardIcon from '@material-ui/icons/ArrowUpward';
import ArrowDownwardIcon from '@material-ui/icons/ArrowDownward';
import './style.css'
class Home extends Component{

    constructor(props){
        super(props);
        this.state={

        }
    }

    render(){
        return(
            <div className='Home col-md-10'>
                <div className='homeHeader'>

                </div>
                <div className='row filaHome'>
                        <div className='col-md-6 cartaHome' >
                        <div className="card">
                            <div className="card-body carta ">
                                <h5 className="card-title">Ingreso del dia</h5>
                             <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                             <AttachMoneyIcon  style={{ color: 'green', fontSize: 80  }}  />

                             </div>
                             
                                
                
                           
                        </div>
                    </div>

                        <div className='col-md-6 cartaHome'>
                        <div className="card ">
                <div className="card-body carta">
                    <h5 className="card-title">Producto mas vendido</h5>
                    
                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <ArrowUpwardIcon style={{ color: 'green', fontSize: 80  }}/>

                </div>
                </div>
                        </div>

                </div>

                <div className='row filaHome'>
                        <div className='col-md-6 cartaHome'>
                        <div className="card ">
                <div className="card-body carta">
                    <h5 className="card-title">Producto menos vendido</h5>
                    
                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <ArrowDownwardIcon style={{ color: 'red', fontSize: 80  }}/>

                </div>
                </div>
                        </div>
                        
                        <div className='col-md-6 cartaHome'>
                        <div className="card ">
                <div className="card-body carta">
                    <h5 className="card-title">Egreso del dia</h5>
                    
                    <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <AttachMoneyIcon style={{ color: 'red', fontSize: 80  }}/>

                </div>
                </div>
                        </div>
                </div>


               
               
            </div>
        );
    }
}

export default Home;