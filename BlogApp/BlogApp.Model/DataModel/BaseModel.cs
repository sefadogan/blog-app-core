using BlogApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.DataModel
{
    public class BaseModel : IEntity
    {
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
