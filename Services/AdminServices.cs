
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using IServices.Sublntefac;

namespace Services
{
    public class AdminServices:IAdminServices
    {
        public List<ModelUserInfo> Users()
        {
            using (var db = new DataContext())
            {
               
                var user = db.Users.Select(ShowUsers()).ToList();
                return user;
            }

        }
        public void Delete(List<int> id)
        {
            using (var db = new DataContext())
            {
                foreach(int item in id)
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == item);
                    var two = db.ChecksEmail.FirstOrDefault(_ => _.UserId == item);
                    db.Users.Remove(user);
                    db.ChecksEmail.Remove(two);
                } 
                db.SaveChanges();
            }
        }
        public void Block(List<int> id)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == item);
                    user.Status = false;
                }
                db.SaveChanges();
            }
        }
            
        public static Expression<Func<User, ModelUserInfo>> ShowUsers()
        {


            return user => new ModelUserInfo()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastVisit = user.LastVisit,
                Status = user.Status
                


        };
           
        }
        
    }
}
