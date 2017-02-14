using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices.Models;

namespace IServices.Sublntefac
{
    public interface IPostServices
    {
        
        List<ModelPost> PostDetails();
        List<ModelPostPreview> PostPreview();
    }
}
