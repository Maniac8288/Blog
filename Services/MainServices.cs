


using IServices;
using IServices.Sublntefac.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
    public class MainServices : IMainServices
    {
        public MainServices()
        {
            Users = new UserServices();
            Post = new PostServices();
       
        
        }
        public IUserServices Users { get; set; }
 
        public IPostServices Post { get; set; }
        
      

    }
}
