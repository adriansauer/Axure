using Axure.DataBase;
using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * SettingsController class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers
{
    [RoutePrefix("Settings")]
    public class SettingsController : Controller
    {

        private SettingDAO settingDAO;

        public SettingsController()
        {
            this.settingDAO = new SettingDAO();
        }

        // GET: Setting/Get
        [Route("Get")]
        public ActionResult Get(Setting setting)
        {
            try
            {
                var value = this.settingDAO.Get(setting.Key);
                if (null != value)
                {
                    return Json(new { Value = value }, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // POST: Setting/Set
        [HttpPut]
        [Route("Set")]
        public ActionResult Set(Setting setting)
        {
            try
            {
                bool error = this.settingDAO.Set(setting.Key, setting.Value);
                if (error)
                {
                    return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
                }
                return new HttpStatusCodeResult(CodeHTTP.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }
    }
}
