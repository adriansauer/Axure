/**librerias de axios */
import axios from "axios";
const requestHelper = axios.create({
  baseURL: "http://localhost:53049/",

});

export default {
  productos: {
    get: () =>
      requestHelper({
        url: "Products/List",
        method: "get",
      }),
     getMateriasPrimas:()=>requestHelper({
      url: "Products/OfType/2" ,
      method: "get",
     }),
     getProductosTerminados:()=>requestHelper({
      url: "Products/OfType/3" ,
      method: "get",
     }),
     getMateriasPrimas_Terminados:()=>requestHelper({
      url: "Products/OfType/1" ,
      method: "get",
     }),
     getProductosDeCompra:()=>requestHelper({
      url: "Products/OfTypeRawMaterialAndBoth" ,
      method: "get",
     }),
     getProductosDeVenta:()=>requestHelper({
      url: "Products/OfTypeFinishedAndBoth " ,
      method: "get",
     }),
    getDeposito: (deposito) =>
      requestHelper({
        url: "Products/OfDeposit/" + deposito,
        method: "get",
      }),
    create: (data) =>
      requestHelper({
        url: "Products/Create",
        method: "post",
        data: data,
      }),
    delete: (id) =>
      requestHelper({
        url: "Products/Delete/" + id,
        method: "delete",
      }),
    edit: (id, data) =>
      requestHelper({
        url: "Products/Edit/" + id,
        method: "put",
        data: JSON.stringify(data),
        headers: {
          "content-type": "application/json; charset=utf-8",
          dataType: "json",
        },
      }),
    getCapital: (deposito) =>
      requestHelper({
        url: "Products/SumDeposit/" + deposito,
        method: "get",
      }),
    getComponents: (id) =>
      requestHelper({
        url: "ProductComponents/OfProduct/" + id,
        method: "get",
      }),
  },
  ordenProduccion: {
    get: () =>
      requestHelper({
        url: "ProductionOrders/List ",
        method: "get",
      }),
    create: (data) =>
      requestHelper({
        url: "ProductionOrders/Create ",
        method: "post",
        data: data,      
      }),
      ordenDetalles: (id) =>
      requestHelper({
        url: "ProductionOrders/Details/"+id,
        method: "get",   
      }),
  },
  empleados: {
    get: () =>
      requestHelper({
        url: "Employees/List",
        method: "get",
      }),
  },
  ingreso_egreso: {
    create: (data) =>
      requestHelper({
        url: "MovementProducts/Add",
        method: "post",
        data:data,
      }),
      get:()=>requestHelper({
        url:"MovementProducts/List",
        method:"get",
      }),
      getMovimientoDetalle:(id)=>requestHelper({
        url:"MovementProductDetails/byMovement/"+id,
        method:"get",
      }),
      delete:(id)=>requestHelper({
        url:"MovementProducts/Delete/"+id,
        method:"delete",
      })
  },
};
