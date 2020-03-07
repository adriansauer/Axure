import React from 'react';

/**importando componentes */
import './Componentes/style.css'
import Body from './Componentes/Body.js';


class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = { width: 0, height: 0 };
    this.updateWindowDimensions = this.updateWindowDimensions.bind(this);
  }
  
  componentDidMount() {
    this.updateWindowDimensions();
    window.addEventListener('resize', this.updateWindowDimensions);
  }
  
  componentWillUnmount() {
    window.removeEventListener('resize', this.updateWindowDimensions);
  }
  
  updateWindowDimensions() {
    this.setState({ width: window.innerWidth, height: window.innerHeight });
  }
 
  render(){
  return (
    
    <div className='App' style={{height:this.state.height,width:this.state.width-15}}>
    
              <Body/>

    </div>
  );
  }
}

export default App;
