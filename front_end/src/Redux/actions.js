import { createAction } from "redux-actions";
import api from "../Axios/Api.js";

export const getMateriasPrimasSuccess = createAction("getMateriasPrimasSuccess");
export const getProductosTerminadosSuccess = createAction("getProductosTerminadosSuccess");
export const getMateriasPrimas_TerminadosSuccess = createAction("getMateriasPrimas_TerminadosSuccess");
export const getProductosSuccess = createAction("getProductosSuccess");
export const getProductosDepositoSuccess=createAction("getProductosDepositoSuccess")
export const setModuloSuccess = createAction("setModuloSuccess");
export const setSectionShow = createAction("setSectionShow");
export const homeVisible = createAction("homeVisible");
export const getEmpleadosSuccess = createAction("getEmpleadosSuccess");

export const getProductos = () => async (dispatch) => {

    const request = await api.productos.get();

    dispatch(getProductosSuccess(request.data));

};
export const getMateriasPrimas = () => async (dispatch) => {
 
    const request = await api.productos.getMateriasPrimas();

    dispatch(getMateriasPrimasSuccess(request.data));
  
};
export const getProductosTerminados = () => async (dispatch) => {
 
  const request = await api.productos.getProductosTerminados();

  dispatch(getProductosTerminadosSuccess(request.data));

};
export const getMateriasPrimas_Terminados = () => async (dispatch) => {
 
  const request = await api.productos.getMateriasPrimas_Terminados();

  dispatch(getMateriasPrimas_TerminadosSuccess(request.data));

};

export const deleteProducto = (id) => async (dispatch) => {
  const request = await api.productos.delete(id);
  dispatch(getProductos());
};
export const getProductosDeposito = (deposito) => async (dispatch) => {
  const productos = await api.productos.getDeposito(deposito);
  dispatch(getProductosDepositoSuccess(productos.data));
};

export const createProducto = (data) => async (dispatch) => {
  const request = await api.productos.create(data);
  dispatch(getProductos());
};
export const editProducto = (id, data) => async (dispatch) => {
  try {
    const request = await api.productos.edit(id, data);
    if (request.state === 200) {
      dispatch(getProductos());
    }
  } catch (error) {}
};

export const getEmpleados = () => async (dispatch) => {
  try {
    const request = await api.empleados.get();
    dispatch(getEmpleadosSuccess(request.data));
  } catch (error) {}
};
