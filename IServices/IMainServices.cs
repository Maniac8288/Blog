
using IServices.Sublntefac;
using IServices.Sublntefac.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IMainServices
    {
        IUserServices Users { get; set; }
        IPostServices Post { get; set; }
       



    }
}
