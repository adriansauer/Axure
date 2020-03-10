import {handleActions} from 'redux-actions';
import {getProductosSuccess,handleError} from '../actions';

export default handleActions({
    [getProductosSuccess]:(state,action)=>{
        return[
            ...state,
            action.payload
        ];
    },
    [handleError]:(state,action)=>{
        return console.log('Ocurrio un error');
    },
    
},[]);