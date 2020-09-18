/**librerias de axios */
import axios from "axios";
import  qs from "qs";
const requestHelper = axios.create({
  baseURL: "http://localhost:53049/",
});

export default {
  token: {
    get: (data) =>
      requestHelper({
        url: "token",
        method: "post",
        data: qs.stringify(data),
      }),
  },
  password:{
    edit:(data)=>requestHelper({
        url: "Users/EditPassword",
        method: "post",
        data: qs.stringify(data),
    }),
  },
  productos: {
    get: () =>
      requestHelper({
        url: "Products/List",
        method: "get",
      }),
    getCategoriaPorveedor: (id) =>
      requestHelper({
        url: "Products/OfProvider/" + id,
        method: "get",
      }),

    getMateriasPrimas: () =>
      requestHelper({
        url: "Stocks/StockDeposit/1",
        method: "get",
      }),
    getProductosTerminados: () =>
      requestHelper({
        url: "Stocks/StockDeposit/3",
        method: "get",
      }),
    getMateriasPrimas_Terminados: () =>
      requestHelper({
        url: "Products/OfType/1",
        method: "get",
      }),
    getProductosDeCompra: () =>
      requestHelper({
        url: "Products/OfTypeRawMaterialAndBoth",
        method: "get",
      }),
    getProductosDeVenta: () =>
      requestHelper({
        url: "Products/OfTypeFinishedAndBoth ",
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
        data
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
        url: "ProductionOrders/Details/" + id,
        method: "get",
      }),
    cambiarEstado: (id, data) =>
      requestHelper({
        url: "ProductionOrders/ChangeState/" + id,
        method: "put",
        data,
      }),
    delete: (id) =>
      requestHelper({
        url: "ProductionOrders/Delete/" + id,
        method: "delete",
      }),
  },
  empleados: {
    get: () =>
      requestHelper({
        url: "Employees/List",
        method: "get",
      }),
  },
  clientes: {
    create: (data) =>
      requestHelper({
        url: "Clients/Create",
        method: "post",
        data: data,
      }),
    get: () =>
      requestHelper({
        url: "Clients/List",
        method: "get",
      }),
    delete: (id) =>
      requestHelper({
        url: "Clients/Delete/" + id,
        method: "post",
      }),
    edit: (id, data) =>
      requestHelper({
        url: "Clients/Edit/" + id,
        method: "post",
        data: data,
      }),
  },
  ordenes_venta: {
    create: (data) =>
      requestHelper({
        url: "OrderSales/Add ",
        method: "post",
        data,
      }),
    get: () =>
      requestHelper({
        url: "OrderSales/List ",
        method: "get",
      }),
    getDetalles: (id) =>
      requestHelper({
        url: "OrderSales/GetById/" + id,
        method: "get",
      }),
  },

  ingreso_egreso: {
    create: (data) =>
      requestHelper({
        url: "MovementProducts/Add",
        method: "post",
        data: data,
      }),
    get: () =>
      requestHelper({
        url: "MovementProducts/List",
        method: "get",
      }),
    getMovimientoDetalle: (id) =>
      requestHelper({
        url: "MovementProductDetails/byMovement/" + id,
        method: "get",
      }),
    delete: (id) =>
      requestHelper({
        url: "MovementProducts/Delete/" + id,
        method: "delete",
      }),
  },

  ordenes_compra: {
    create: (data) =>
      requestHelper({
        url: "PurchaseOrders/Create",
        method: "post",
        data: data,
      }),

    get: () =>
      requestHelper({
        url: "PurchaseOrders/List",
        method: "get",
      }),

   
    getDetalles: (id) =>
      requestHelper({
        url: "PurchaseOrders/Details/" + id,
        method: "get",
      }),
  },

  factura_compra: {
    create: (data) =>
      requestHelper({
        url: "ProviderInvoices/Create",
        method: "post",
        data: data,
      }),
        
    get: ()=>
    requestHelper({
      url: "ProviderInvoices/List",
      method: "get",
    }),

  getDetalles: (id)=>
    requestHelper({
      url: "ProviderInvoices/ListDetails/" + id,
      method: "get",
    })
  },

  proveedores: {
    get: () =>
      requestHelper({
        url: "Providers/List",
        method: "get",
      }),

    getDetalles: (id) =>
      requestHelper({
        url: "Providers/Details/" + id,
        method: "get",
      }),
  },
  factura: {
    validate: (data) =>
      requestHelper({
        url: "Invoices/Validate",
        method: "post",
        data: data,
      }),
    create: (data) =>
      requestHelper({
        url: "Invoices/Create",
        method: "post",
        data,
      }),
    get: () =>
      requestHelper({
        url: "Invoices/List",
        method: "get",
      }),
  },
  categoria: {
    get: (data) =>
      requestHelper({
        url: "ProductCategories/List",
        method: "post",
        data: data,
      }),
  },
  proveedor: {
    create: (data) =>
      requestHelper({
        url: "Providers/Create",
        method: "post",
        data,
      }),
  },
  settings: {
    /**-	ID_DEPOSIT_RAW_MATERIAL
-	ID_DEPOSIT_PRODUCTION
-	ID_DEPOSIT_SALE 
-	ID_TYPE_OF_PRODUCT_RAW_MATERIAL_AND_FINISHED
-	ID_TYPE_OF_PRODUCT_RAW_MATERIAL
-	ID_TYPE_OF_PRODUCT_FINISHED
-	AUTOMATIC_PRODUCTION_ORDER
-	ID_PRODUCTION_STATE_PENDING
-	ID_PRODUCTION_STATE_PROGRESS
-	ID_PRODUCTION_STATE_FINALIZED
-	ID_PRODUCTION_STATE_CANCELLED
 */
    get: (data) =>
      requestHelper({
        url: "Settings/Get",
        method: "post",
        data: { Key: data },
      }),
  },
};
