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
        readonly BlogAppContext _context;

        public UserRepository(BlogAppContext context) : base(context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Set<User>().Find(id).IsActive = false;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
