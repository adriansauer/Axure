using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.Models
{
    public class UserMasterRepository : IDisposable
    {
        AxureContext context = new AxureContext();

        public User ValidateUser(string username, string password)
        {
            return context.Users.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}