import React,{Component} from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import './style.css';
import HomeIcon from '@material-ui/icons/Home';
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
                <HomeIcon/> 
              
                </Typography>
            </Toolbar>
        </AppBar>
        </div>
    );
    }
}
export default Header;