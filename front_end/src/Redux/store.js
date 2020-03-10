import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import productos from './Reducers/productos.js';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';

const reducer=combineReducers({
   productos,
   sectionShow,
   homeVisible,
   
});

export default createStore(reducer,applyMiddleware(thunk));

