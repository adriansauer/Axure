import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as serviceWorker from './Servicios/serviceWorker';
import 'bootstrap/dist/js/bootstrap.bundle.min';	
import 'bootstrap/dist/css/bootstrap.min.css';
import store from './Redux/store.js';
import {Provider} from 'react-redux';
import 'react-app-polyfill/ie11';
import 'react-app-polyfill/stable';
const node=( 
    <Provider store={store}>
    <App/>
    </Provider>
)
   

ReactDOM.render(node, document.getElementById('root'));

serviceWorker.unregister();
