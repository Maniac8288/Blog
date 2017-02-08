using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using DataModel;
using Services.Models;
using Rework;
using Blog;

namespace Services
{
    class RegisterServices : IRegisterServices
    {
    public void Register(string userName, string password)
        {
            string sha256 = password.ToSHA(Crypto.SHA_Type.SHA256);
            string salt = Security.instance.getSalt();
            using (var db = new DataContext())
            {
                User user = new User()
            {
                   UserName = userName,
                  Password = salt+sha256,
                 Salt = salt
                     };
                         db.Users.Add(user);
                         db.SaveChanges();
            }
        }
    }
}
