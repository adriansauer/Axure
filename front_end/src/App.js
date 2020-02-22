import React from 'react';
/**librerias de redux */
import {Provider} from 'react-redux';
import store from './store.js';
/**librerias de redact Router */
import {BrowserRouter,Route} from 'react-router-dom';

/**importando componentes */
import Login from './Login.js';
import Registro from './Registro.js';
import Home from './Home.js';
/**import Error404 from './Error404.js'; */

class App extends React.Component {
  constructor(props){
    super(props);
    this.state={

    }
  }
 
  render(){
  return (
    
    <Provider store={store}>
     
     <BrowserRouter>
    <React.Fragment>
      <Route exact path='/registro' component={Registro}/>
      <Route exact path='/home' component={Home}/>
      <Route exact path='/login' component={Login}/>
      
     
    </React.Fragment>
    </BrowserRouter>
     
    </Provider>
    
  );
  }
}

export default App;
