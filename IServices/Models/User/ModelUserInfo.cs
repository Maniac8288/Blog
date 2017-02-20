using System;
using System.Collections.Generic;
using DataModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.User
{
 public   class ModelUserInfo
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        public string dateBird { get; set; }
        public DateTime DateRegister { get; set; }
        public string Email { get; set; }
        public List<ModelRole> Roles { get; set; }
        public DateTime LastVisit { get; set; }
        public EnumStatusUser Status { get; set; }
    }
}
