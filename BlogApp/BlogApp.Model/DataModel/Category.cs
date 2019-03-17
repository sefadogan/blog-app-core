using BlogApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.DataModel
{
    public class Category : BaseModel, IEntity
    {
        public int CategoryId { get; set; }
        public int Name { get; set; }
    }
}
