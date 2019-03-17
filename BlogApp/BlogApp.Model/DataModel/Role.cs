using BlogApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.DataModel
{
    public class Role : BaseModel, IEntity
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
