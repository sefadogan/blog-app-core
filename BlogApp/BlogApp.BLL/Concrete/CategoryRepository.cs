using BlogApp.BLL.Abstract;
using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Concrete
{
    public class CategoryRepository : BaseRepository<Category, int, BlogAppContext>, ICategoryRepository
    {
        public CategoryRepository(BlogAppContext context) : base(context)
        {
        }
    }
}
