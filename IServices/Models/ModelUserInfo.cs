using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
 public   class ModelUserInfo
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        public string dateBird { get; set; }
        public DateTime DateRegister { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime LastVisit { get; set; }
        public bool Status { get; set; }
    }
}
