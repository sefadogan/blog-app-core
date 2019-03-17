using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Abstract
{
    public interface IPostRepository: IBaseRepository<Post, int, BlogAppContext>
    {
    }
}
