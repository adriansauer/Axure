/**librerias de axios */
import axios from "axios";
const requestHelper = axios.create({
  baseURL: "http://localhost:53049/",
  origin: "http://127.0.0.1/3000",
});

export default {
  productos: {
    get: () =>
      requestHelper({
        url: "Products/List",
        method: "get",
      }),
      getStockProduct:(id)=>requestHelper({
        url: "Stocks/Quantity/"+id,
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
        method: "get",
      }),
    create: (data) =>
      requestHelper({
        url: "ProductionOrders/Create ",
        method: "post",
        data: data,      
      }),
  },
  empleados: {
    get: () =>
      requestHelper({
        url: "Employees/List",
        method: "get",
      }),
  },
};
