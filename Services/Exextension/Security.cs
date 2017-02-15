using DataModel.Models;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exextension
{
  public static  class Security
    {
        /// <summary>
        /// Хэширует методом SHA256
        /// </summary>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Хешированый пароль пользователя</returns>
      public  static string sha256(this string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
      


        /// <summary>
        /// Метод создающий соль
        /// </summary>
        /// <returns>Возвращает соль</returns>
        public static string getSalt()
            {
                var random = new RNGCryptoServiceProvider();

                // Maximum length of salt
                int max_length = 32;

                // Empty salt array
                byte[] salt = new byte[max_length];

                // Build the random bytes
                random.GetNonZeroBytes(salt);

                // Return the string encoded salt
                return Convert.ToBase64String(salt);
            }
        }
    }
