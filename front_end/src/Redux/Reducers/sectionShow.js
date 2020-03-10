import {handleActions} from 'redux-actions';
import {setSectionShow} from '../actions.js';

export default handleActions({
    [setSectionShow]:(state,action)=>{
       
        return[action.payload];
    },

},[]);