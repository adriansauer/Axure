import {createStore,combineReducers,applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import sectionShow from './Reducers/sectionShow.js';
import homeVisible from './Reducers/homeVisible.js';

const reducer=combineReducers({

   sectionShow,
   homeVisible,
});

export default createStore(reducer,applyMiddleware(thunk));

