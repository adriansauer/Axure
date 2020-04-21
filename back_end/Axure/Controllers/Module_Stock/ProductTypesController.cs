using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductTypes")]
    public class ProductTypesController : Controller
    {
        //Atributos.
       /* private ProductTypeDB productTypeDB;

        //Constructor de la clase.
        public ProductTypesController()
        {
            this.productTypeDB = new ProductTypeDB();
        }

        // GET: Datos del modelo producto.
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", TypeP = "True"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: Todos los tipos de productos existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productTypeDB.ObtenerTodosTiposProductos();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }

        }

        // GET: ProductTypes/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productTypeDB.DetalleTipoProducto(id);
                if (null != dato)
                {
                    return Json(dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(202);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: ProductTypes/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductTypeDTO pt)
        {
            try
            {
                if (this.productTypeDB.Agregar(pt))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }                
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: ProductTypes/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductType pt)
        {
            try
            {
                if (this.productTypeDB.Editar(id, pt))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: ProductTypes/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productTypeDB.darDeBaja(id))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }

            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }*/
    }
}
