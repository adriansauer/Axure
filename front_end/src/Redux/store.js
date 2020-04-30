import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import productos from './Reducers/productos.js';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';
import empleados from './Reducers/empleados.js';
import productoDeDeposito from "./Reducers/productoDeDeposito.js"
import materiasPrimas from "./Reducers/materiasPrimas.js"
import productosTerminados from "./Reducers/productosTerminados.js"
import materiasPrimas_Terminados from "./Reducers/materiasPrimas_Terminados.js"

const reducer=combineReducers({
   productos,
   sectionShow,
   homeVisible,
   productoDeDeposito,
   empleados,
   materiasPrimas,
   productosTerminados,
   materiasPrimas_Terminados,
   
});

export default createStore(reducer,applyMiddleware(thunk));

