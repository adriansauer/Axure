import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import productos from './Reducers/productos.js';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';
import materias_primas from './Reducers/materias_primas.js';
import productos_terminados from './Reducers/productos_terminados.js';
import productos_en_produccion from './Reducers/productos_en_produccion.js';
import capitalTotal from './Reducers/capitalTotal.js';
import capitalDeposito from './Reducers/capitalDeposito.js';


const reducer=combineReducers({
   productos,
   materias_primas,
   productos_terminados,
   productos_en_produccion,
   sectionShow,
   homeVisible,
   capitalTotal,
   capitalDeposito,

   
});

export default createStore(reducer,applyMiddleware(thunk));

