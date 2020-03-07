import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import productos from './Reducers/productos.js';
import sectionShow from './Reducers/sectionShow';



const reducer=combineReducers({
   productos,
   sectionShow,
   
});

export default createStore(reducer,applyMiddleware(thunk));