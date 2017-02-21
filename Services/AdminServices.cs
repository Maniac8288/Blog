using IServices;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Admin;

namespace Services
{
    public class AdminServices : IAdminServices
    {
        public AdminServices()
        {
            Users = new AdminUsersServices();
            Categories = new AdminCategoriesServices();
        }
        public IAdminUsersServices Users { get; set; }
        public IAdminCategoriesServices Categories { get; set; }



    }
}
