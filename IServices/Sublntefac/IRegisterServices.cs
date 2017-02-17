﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IServices
{
    public interface IRegisterServices
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Никнейм</param>
        /// <param name="password">Пароль</param>
        /// <param name="dataBird">Дата Рождения</param>
        /// <param name="email">Емаил пользователя</param>
        /// <returns>Вывод случайного слово для потверждения Email</returns>
        string Register(string userName, string password,DateTime dataBird, string email);
        /// <summary>
        /// Потверждения Email
        /// </summary>
        /// <param name="salt">Случайное слово</param>
        /// <param name="userName">Никнейм</param>
        /// <returns></returns>
        bool ConfrimedEmail(string salt,string userName);
    }
}
