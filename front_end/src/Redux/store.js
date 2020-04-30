import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import productos from './Reducers/productos.js';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';
import capitalTotal from './Reducers/capitalTotal.js';
import capitalDeposito from './Reducers/capitalDeposito.js';
import empleados from './Reducers/empleados.js';


const reducer=combineReducers({
   productos,
   sectionShow,
   homeVisible,
   capitalTotal,
   capitalDeposito,
   empleados,
   
});

export default createStore(reducer,applyMiddleware(thunk));

