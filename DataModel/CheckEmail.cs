using DataModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The DataModel namespace.
/// </summary>
namespace DataModel
{

    /// <summary>
    /// Модель проверки почты
    /// </summary>
    public class CheckEmail
    {
        /// <summary>
        /// ИД пользователя.
        /// </summary>
        [Key]
        [ForeignKey("UserOf")]
        public int UserId { get; set; }
        /// <summary>
        /// Задает значение потверждение почты.
        /// </summary>
        public bool ConfirmedEmail { get; set; }
        /// <summary>
        /// Код потверждения почты.
        /// </summary>
        /// <value>Потврждение почты.</value>
        public string ConfirmationCode { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        /// <value>Пользователь.</value>
        public User UserOf { get; set; }
    }
}
