using BlogApp.BLL.Abstract;
using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Concrete
{
    public class RoleRepository : BaseRepository<Role, int, BlogAppContext>, IRoleRepository
    {
        public RoleRepository(BlogAppContext context) : base(context)
        {
        }
    }
}
