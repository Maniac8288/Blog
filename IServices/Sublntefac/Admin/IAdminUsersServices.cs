using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
   public interface IAdminUsersServices
    {
        void Delete(List<int> id);
        List<ModelUserInfo> Users();
        void Block(List<int> id);
      
    }
}
