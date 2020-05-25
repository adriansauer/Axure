import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';
import modulo from './Reducers/modulo.js';
const reducer=combineReducers({

   sectionShow,
   homeVisible,
   modulo,
});

export default createStore(reducer,applyMiddleware(thunk));

