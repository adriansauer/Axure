import React,{Component} from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import './style.css';
import HomeIcon from '@material-ui/icons/Home';
import {connect} from 'react-redux';
import {homeVisible} from '../Redux/actions.js';
class Header extends Component {
    constructor(props){
        super(props);
        this.state={}
    }
    
    render(){
      
    return(
        <div className="Header row">
        <AppBar position="static">
            <Toolbar>
                <Typography variant="title" color="inherit">
                AXure
                <HomeIcon className='homeIcono' onClick={()=>this.props.homeVisible(true)}/> 

                </Typography>
            </Toolbar>
        </AppBar>
        </div>
    );
    }
}
const mapStateToProps=state=>{
    return{
      
    }
}
const mapDispatchToProps={
homeVisible,

}
export default connect(mapStateToProps,mapDispatchToProps)(Header);