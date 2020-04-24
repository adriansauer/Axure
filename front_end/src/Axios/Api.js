/**librerias de axios */
import axios from "axios";
const requestHelper = axios.create({
  baseURL: "http://localhost:53049/",
  headers:{
      'content-type':'application/json',
      
  }
});

export default {
  productos: {
    get: () =>
      requestHelper({
        url: "Products/List",
        method: "get"
      }),
    getDeposito: deposito =>
      requestHelper({
        url: "Products/OfDeposit/" + deposito,
        method: "get"
      }),
    create: data =>
      requestHelper({
        url: "Products/Create",
        method: "post",
        data: data
      }),
    delete: id =>
      requestHelper({
        url: "Products/Delete/" + id,
        method: "delete"
      }),
    edit: (id, data) =>
      requestHelper({
        url: "Products/Edit/" + id,
        method: "put",
        data: JSON.stringify(data),
        headers:{
          'content-type': 'application/json; charset=utf-8',
          'dataType': 'json',
        }
      }),
    getCapital: deposito =>
      requestHelper({
        url: "Products/SumDeposit/" + deposito,
        methot: "get"
      }),
      getComponents:id=>
      requestHelper({
        url:'ProductComponents/OfProduct/'+id,
        method:'get'
      })
  },
  ordenProduccion:{
    get:()=>requestHelper({
      methot: "get"
    }),
    create:(data)=>requestHelper({
      url:"ProductionOrders/Create ",
      methot: "post",
      data: JSON.stringify(data),
        headers:{
          'content-type': 'application/json; charset=utf-8',
          'dataType': 'json',
          "Access-Control-Allow-Origin": "http://127.0.0.1:3000"
        }
      
    }),
    
  },
  empleados:{
    get:()=>requestHelper({
      url:"Employees/List",
      method:"get"
      
    })
  }
};
