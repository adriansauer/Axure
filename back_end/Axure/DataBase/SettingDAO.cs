using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * SettingDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase
{
    public class SettingDAO
    {
        public SettingDAO()
        {

        }

        public string Get (string Key)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.Settings.FirstOrDefault(x => x.Key == Key).Value;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Set (string Key, string Value)
        {
            try
            {
                using(var db = new AxureContext())
                {
                    Setting setting = db.Settings.FirstOrDefault(x => x.Key == Key);
                    setting.Value = Value;
                    db.SaveChanges();
                    return false;
                }
            }catch(Exception e)
            {
                return true;
            }
        }
    }
}