using DataModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
   
   public class CheckEmail
    {
        [Key]
        [ForeignKey("UserOf")]
        public int UserId { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string ConfirmationCode { get; set; }
        public User UserOf { get; set; }
    }
}
