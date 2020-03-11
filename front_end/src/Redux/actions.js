import {createAction} from 'redux-actions';

import api from '../Axios/Api.js';

export const handleError=createAction('handleError');
export const getProductosSuccess=createAction('getProductosSuccess');

/**Devuelve todos los productos de la api */
export const getProductos=()=>async(dispatch)=>{
    try {
        const request=await api.productos.get();
       
        dispatch(getProductosSuccess(request.data));
       
        
    } catch (error) {
       
        dispatch(handleError(error));
    }

}
/**agrega un producto y vuelve a solicitar todos los productos de la api */
export const createProducto=(data)=>async(dispatch)=>{
    try {
        const request=await api.productos.create(data);
        dispatch(getProductosSuccess());
    } catch (error) {
        dispatch(handleError(error));
  
    }
}

export const postProductos=createAction('postProductos');


/**Modificar la vista del section y el home*/
export const setSectionShow=createAction('setSectionShow');
export const homeVisible=createAction('homeVisible');


