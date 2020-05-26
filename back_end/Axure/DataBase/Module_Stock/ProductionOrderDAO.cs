using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;

/*
 * ProductionOrderDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class ProductionOrderDAO
    {
        
        ProductDAO productDAO;

        public ProductionOrderDAO()
        {
            this.productDAO = new ProductDAO();
        }
 
        public List<ProductionOrderReportDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetailDAO productionOrderDetailDB = new ProductionOrderDetailDAO();
                    var opList = db.ProductionOrders.Include("ProductionStates").Where(x => x.Deleted == false)
                           .Select(x => new { Id = x.Id, ProductionState = x.ProductionState, EmployeeId = x.EmployeeId, Date = x.Date , Observation = x.Observation })
                           .ToList()
                           .Select(y => new ProductionOrderReportDTO() { Id=y.Id, ProductionState = y.ProductionState, EmployeeId = y.EmployeeId, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Observation = y.Observation })
                           .ToList();
                    //opList.ForEach(x => x.ListDetails = productionOrderDetailDB.GetAllProductionOrderDetails(x.Id));
                       return opList;
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionOrderReportDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetailDAO productionOrderDetailDAO = new ProductionOrderDetailDAO();
                    var po = db.ProductionOrders.Include("ProductionState").FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    return new ProductionOrderReportDTO() { Id = po.Id, ProductionState = po.ProductionState, EmployeeId = po.EmployeeId, Day = po.Date.Day, Month = po.Date.Month, Year = po.Date.Year, Observation = po.Observation, ListDetails = productionOrderDetailDAO.GetAllProductionOrderDetails(id) };
                }
            }
            catch
            {
                return null;
            }

        }

        public bool Add(ProductionOrderDTO orden)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder nuevo = new ProductionOrder() { ProductionStateId = orden.ProductionStateId,  EmployeeId=orden.EmployeeId, Observation = orden.Observation, Date = new DateTime(orden.Year, orden.Month, orden.Day), Deleted = false };
                    db.ProductionOrders.Add(nuevo);
                    db.SaveChanges();
                    ProductionOrderDetailDAO productionOrderDetailDAO = new ProductionOrderDetailDAO();
                    if(null != orden.ListDetails)
                    {
                        for (int i = 0; i < orden.ListDetails.Count; i++)
                        {
                            orden.ListDetails[i].ProductionOrderId = nuevo.Id;
                            productionOrderDetailDAO.Add(orden.ListDetails[i]);
                        }
                    }
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductionOrderDTO po)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder poEditado = db.ProductionOrders.FirstOrDefault(x => x.Id == id);
                    poEditado.ProductionStateId = po.ProductionStateId;
                    poEditado.EmployeeId = po.EmployeeId;
                    poEditado.Observation = po.Observation;
                    poEditado.Date = new DateTime(po.Year, po.Month, po.Day);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool EditState(int id, int stateId, int employeeId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder poEditado = db.ProductionOrders.FirstOrDefault(x => x.Id == id);
                    poEditado.ProductionStateId = stateId;
                    poEditado.EmployeeId = employeeId;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder bajar = db.ProductionOrders.FirstOrDefault(x => x.Id == id);
                    bajar.Deleted = true;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder po = db.ProductionOrders.Single(x => x.Id == id);
                    if (null == po) { return true; }
                    db.ProductionOrders.Remove(po);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public List<int> ChangeState(int idOrden, ProductionOrderDTO ps)
        {
            try
            {
                SettingDAO settingDAO = new SettingDAO();
                ProductionOrderReportDTO po = Detail(idOrden);
                if (ps.ProductionStateId == int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_PROGRESS")))
                {
                    List<int> status = StatusInProgress(idOrden, ps.EmployeeId);
                    if (null != status)
                    {
                        return status;
                    }
                }
                else if (ps.ProductionStateId == int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_FINALIZED")))
                {
                    if (!StatusInFinalized(idOrden, ps.EmployeeId))
                    {
                        return new List<int>();
                    }
                }else if (ps.ProductionStateId == int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_CANCELLED")))
                {
                    if (!StatusInCancelled(idOrden, ps.EmployeeId))
                    {
                        return new List<int>();
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private List<int> StatusInProgress(int idOrden, int employeId)
        {
            try
            {
                ProductionOrderDetailDAO productionOrderDetailDAO = new ProductionOrderDetailDAO();
                StockDAO stockDAO = new StockDAO();
                SettingDAO settingDAO = new SettingDAO();
                List<ProductionOrderDetailDTO> listDetails = productionOrderDetailDAO.GetAllProductionOrderDetails(idOrden);
                List<int> notStock = stockDAO.CheckStock(listDetails, int.Parse(settingDAO.Get("ID_DEPOSIT_RAW_MATERIAL")));
                if (null == notStock)
                {
                    return null;
                }
                else if (0 == notStock.Count())
                {
                    if (!EditState(idOrden, int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_PROGRESS")), employeId))
                    {
                        return notStock;
                    }
                    return null;
                }
                else
                {
                    return notStock;
                }
            }
            catch
            {
                return null;
            }
        }

        
        private bool StatusInFinalized(int idOrden, int employeId)
        {
            try
            {
                SettingDAO settingDAO = new SettingDAO();
                ProductionOrderDAO productionOrderDAO = new ProductionOrderDAO();
                ProductionOrderReportDTO po = productionOrderDAO.Detail(idOrden);
                if (int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_PROGRESS")) == po.ProductionState.Id)
                {
                    if (!EditState(idOrden, int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_FINALIZED")), employeId))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        private bool StatusInCancelled(int idOrden, int employeId)
        {
            try
            {
                SettingDAO settingDAO = new SettingDAO();
                if (!EditState(idOrden, int.Parse(settingDAO.Get("ID_PRODUCTION_STATE_CANCELLED")), employeId))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}