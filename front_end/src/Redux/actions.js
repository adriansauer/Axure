import { createAction } from "redux-actions";

import api from "../Axios/Api.js";

export const handleError = createAction("handleError");
/**Obtener todos los productos */
export const getProductosSuccess = createAction("getProductosSuccess");


/**Modificar la vista del section y el home*/
export const setSectionShow = createAction("setSectionShow");
export const homeVisible = createAction("homeVisible");



/**Devuelve todos los productos de la api */
export const getProductos = () => async dispatch => {
  try {
    const request = await api.productos.get();

    dispatch(getProductosSuccess(request.data));
  } catch (error) {
console.log('Error de conexion')  }
};

/**eliminar un producto y volver a solicitar todos los productos */

export const deleteProducto=(id)=>async dispatch=>{
  
    const request=await api.productos.delete(id);
    if(request.status===200){
      dispatch(getProductos());
      console.log('respuesta: ',request);
    }else{
      console.log('Error al intentar eliminar el producto');
    }
      
    
}
/**agregar un producto y volver a solicitar todos los productos para actualizar el estado */

export const createProducto=(data)=>async dispatch=>{
  const request=await api.productos.create(data);
  
    
    console.log('respuesta del create producto:',request);
 
  
}