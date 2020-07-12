using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase
{
    public class UserDAO
    {
        public bool Edit(User u)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    User userEdit = db.Users.FirstOrDefault(x => x.UserName.Equals(u.UserName));
                    userEdit.Password = u.Password;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}