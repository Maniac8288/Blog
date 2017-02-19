using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices.Models;
using IServices.Models.Post;


namespace IServices.Sublntefac.Public
{
    public interface IPostServices
    {
        
        List<ModelPost> PostDetails();
        List<ModelPostPreview> PostPreview();
    }
}
