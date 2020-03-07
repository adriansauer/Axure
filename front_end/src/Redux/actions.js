import {createAction} from 'redux-actions';

import api from '../Axios/Api.js';

export const handleError=createAction('handleError');
export const getProductosSuccess=createAction('getProductosSuccess');


export const getProductos=()=>async(dispatch)=>{
    try {
        const request=await api.productos.get();
       
        dispatch(getProductosSuccess(request.data))
    } catch (error) {
       
        dispatch(handleError(error));
    }

}

export const postProductos=createAction('postProductos');


/**Modificar la vista del section */
export const setSectionShow=createAction('setSectionShow');