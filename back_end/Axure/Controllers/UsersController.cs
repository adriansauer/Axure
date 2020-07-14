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

        // POST: Users/EditPassword
        [HttpPost]
        [Route("EditPassword")]
        public ActionResult EditPassword(User u)
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
