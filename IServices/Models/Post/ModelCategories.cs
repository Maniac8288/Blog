using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.Post
{
    public  class ModelCategories
    {
        
        public List<ModelCategory> Categories { get; set; }

        public List<ModelCategory> GetParents() { return Categories.Where(_ => !_.ParentId.HasValue).ToList(); }

        public ModelCategory GetParent(int? parentId) { return Categories.FirstOrDefault(_ => _.Id == parentId); }

        public List<ModelCategory> GetChild(int? parentId) { return Categories.Where(_ => _.ParentId == parentId).ToList(); }
    }
}
