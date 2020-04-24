import { createAction } from "redux-actions";
import api from "../Axios/Api.js";

export const handleError = createAction("handleError");
/**Obtener todos los productos */
export const getProductosSuccess = createAction("getProductosSuccess");
export const getMateriasPrimasSuccess = createAction(
  "getMateriasPrimasSuccess"
);
export const getProductosEnProduccionSuccess = createAction(
  "getProductosEnProduccionSuccess"
);
export const getProductosTerminadosSuccess = createAction(
  "getProductosTerminadosSuccess"
);
/**obtener el capital todos los productos existentes en los depositos*/
export const getCapitalTotalSuccess = createAction("getCapitalTotalSuccess");
/**obtiene el capital de todos los productos de un deposito en especifico */
export const getCapitalDepositoSuccess = createAction("getCapitalSuccess");
/**cambiar el modulo */
export const setModuloSuccess = createAction("setModuloSuccess");

/**Modificar la vista del section y el home*/
export const setSectionShow = createAction("setSectionShow");
export const homeVisible = createAction("homeVisible");
export const getEmpleadosSuccess = createAction("getEmpleadosSuccess");

/**Devuelve todos los productos de la api */
export const getProductos = () => async (dispatch) => {
  try {
    const request = await api.productos.get();

    dispatch(getProductosSuccess(request.data));
  } catch (error) {}
};
/**devuelve todos los productos que son materia prima de la api */
export const getMateriasPrimas = () => async (dispatch) => {
  try {
    const request = await api.productos.getDeposito(1);
    dispatch(getMateriasPrimasSuccess(request.data));
  } catch (error) {}
};
/**devuelve todos los productos que son productos terminados */
export const getProductosTerminados = () => async (dispatch) => {
  try {
    const request = await api.productos.getDeposito(3);
    dispatch(getProductosTerminadosSuccess(request.data));
  } catch (error) {}
};
/**devuelve todos los productos que estan en produccion */
export const getProductosEnProduccion = () => async (dispatch) => {
  try {
    const request = await api.productos.getDeposito(2);
    dispatch(getProductosEnProduccionSuccess(request.data));
  } catch (error) {}
};

/**eliminar un producto y volver a solicitar todos los productos */

export const deleteProducto = (id) => async (dispatch) => {
  const request = await api.productos.delete(id);

  if (request.status === 200) {
  } else {
  }
};
/**devuelve el capital total de los productos de un deposito especifico */
export const getCapitalTotal = () => async (dispatch) => {
  try {
    const request1 = await api.productos.getCapital(1);
    const request2 = await api.productos.getCapital(2);
    const request3 = await api.productos.getCapital(3);
    const request = request1.data.Sum + request2.data.Sum + request3.data.Sum;

    dispatch(getCapitalTotalSuccess(request));
  } catch (error) {}
};
/**devuelve el capital de todos los productos de un deposito en especifico */
export const getCapitalDeposito = (deposito) => async (dispatch) => {
  try {
    const request = await api.productos.getCapital(deposito);

    dispatch(getCapitalDepositoSuccess(request.data.Sum));
  } catch (error) {}
};
/**agregar un producto y volver a solicitar todos los productos para actualizar el estado */

export const createProducto = (data) => async (dispatch) => {
  try {
    const request = await api.productos.create(data);

    if (request.status === 200) {
      dispatch(getProductos);
      dispatch(getMateriasPrimas);
      dispatch(getProductosTerminados);
    }
  } catch (error) {}
};
/**Permite editar un producto */
export const editProducto = (id, data) => async (dispatch) => {
  try {
    const request = await api.productos.edit(id, data);
    if (request.state === 200) {
      dispatch(getProductos);
      dispatch(getMateriasPrimas);
      dispatch(getProductosTerminados);
    }
  } catch (error) {}
};

/**obtener todos los empleados de la api */
export const getEmpleados = () => async (dispatch) => {
  try {
    const request = await api.empleados.get();
    dispatch(getEmpleadosSuccess(request.data));
  } catch (error) {}
};
