using BlogApp.BLL.Abstract;
using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Concrete
{
    public class UserRepository : BaseRepository<User, int, BlogAppContext>, IUserRepository
    {
        public UserRepository(BlogAppContext context) : base(context)
        {
        }
    }
}
