import React,{Component} from 'react';
import Header from './Header.js';
import Menu from './Menu.js';
import Aside from './Aside.js';
import Section from './Section.js';
import './style.css'
class Body extends Component{
    constructor(props){
        super(props);
        this.state={}
    }

    render(){
        return(
            <div className="Body">
                <Header/>
                <div className='Box row'>
                <Menu/>
                <Section/>
                <Aside/>
                </div>

            </div>
        );
    }
}
export default Body;