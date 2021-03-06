﻿using System.Data.Entity;
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
using Services.Exextension;

/// <summary>
/// Функционал админки
/// </summary>
namespace Services.Admin
{
    /// <summary>
    /// Управления пользователями
    /// </summary>
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
        /// Добавляет роль пользователю 
        /// </summary>
        /// <param name="id">Список пользователй</param>
        /// <param name="role">Выбранная роль</param>
        public void roleUsers(List<int> id,string roleID)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var user = db.Users.Include(x=>x.Roles).FirstOrDefault(_ => _.Id == item);
                    if (roleID == "User")
                    {
                        user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList();
                    }
                    if (roleID == "Admin")
                    {
                        user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.Admin).ToList();
                    }
                  
                }
               db.SaveChanges(); 
               
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
        /// <summary>
        /// Метод реализующий регистрацию 
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dataBird">Дата рождения пользователя</param>
        public string Register(string userName, string password, DateTime dataBird, string email)
        {

            string salt = Security.getSalt();
            using (var db = new DataContext())
            {


                User NewUser = new User()
                {
                    UserName = userName,
                    Password = (salt + password).sha256(),
                    Salt = salt,
                    Datebirth = dataBird,
                    Email = email,
                    StatusUserId = EnumStatusUser.NConfirmed,
                    CheckEmail = new CheckEmail
                    {
                        ConfirmedEmail = false,
                        ConfirmationCode = salt
                    },
                    Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                };
                db.Users.Add(NewUser);
                db.SaveChanges();
                return salt;



            }

        }

    }
}
