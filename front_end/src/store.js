import {createStore} from 'redux';

const initialState={
    url:'http://localhost:53049/token',
    user:{},
    token:'',
    
}

function reducer(state=initialState,action){
   switch(action.type){
        case 'LOGIN':
            return{
                ...state,
                user:{'UserName':action.user.UserName, 'Password':action.user.Password},
                token:action.token
            }
                    
        default: return state;
             
    }
    
   
}

export default createStore(reducer);