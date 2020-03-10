import {handleActions} from 'redux-actions';
import {homeVisible} from '../actions';

export default handleActions({
    
    [homeVisible]:(state,action)=>{
       
        return [action.payload];
    },
    
},[]);