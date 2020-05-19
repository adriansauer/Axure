import {handleActions} from 'redux-actions';
import {setModulo} from '../actions';

export default handleActions({
    
    [setModulo]:(state,action)=>{
       
        return [action.payload];
    },
    
},[]);