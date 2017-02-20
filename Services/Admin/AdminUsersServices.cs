using System.Data.Entity;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using IServices.Sublntefac;
using IServices.Sublntefac.Admin;
using IServices.Models.User;

namespace Services.Admin
{
    public class AdminUsersServices : IAdminUsersServices
    {
        /// <summary>
        /// Вывод всех пользовотелей 
        /// </summary>
        /// <returns></returns>
        public List<ModelUserInfo> Users()
        {
           
            using (var db = new DataContext())
            {
               
                var user = db.Users.Select(ShowUsers()).ToList();
                return user;
            }

        }
        /// <summary>
        /// Удаление из бд выбраного пользователя
        /// </summary>
        /// <param name="id">Список пользователй</param>
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
        /// <summary>
        /// Изменяет статус в бд на false
        /// </summary>
        /// <param name="id">Список пользователй </param>
        public void Block(List<int> id)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == item);
                    user.StatusUserId = EnumStatusUser.Locked;
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        public void roleUsers(List<int> id,string role)
        {
            using (var db = new DataContext())
            {
                
                foreach (int item in id)
                {
                    var user = db.Users.Include(x=>x.Roles).FirstOrDefault(_ => _.Id == item);
                    if (role == "User")
                    {
                
                        user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList();
                     
                    }
                    if (role == "Admin")
                    {
                      
                        user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.Admin).ToList();
                    }
                  
                }
                try { db.SaveChanges(); }
                catch(Exception ex) { }
            }
        }
        /// <summary>
        /// Изменяет модель "ModelUserInfo" на "User"
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<User, ModelUserInfo>> ShowUsers()
        {

            return user => new ModelUserInfo()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastVisit = user.LastVisit,
                Status = user.StatusUserId,
                Roles = user.Roles.Select(role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name }).ToList()

            };
           
        }
        
    }
}
