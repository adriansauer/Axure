using Axure.DataBase;
using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UserDAO userDAO;

        public UsersController()
        {
            this.userDAO = new UserDAO();
        }

        // POST: Users/Edit
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(User u)
        {
            try
            {
                if (this.userDAO.Edit(u))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }
    }
}
