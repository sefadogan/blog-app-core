using BlogApp.BLL.Abstract;
using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Concrete
{
    public class PostRepository : BaseRepository<Post, int, BlogAppContext>, IPostRepository
    {
        public PostRepository(BlogAppContext context) : base(context)
        {
        }
    }
}
