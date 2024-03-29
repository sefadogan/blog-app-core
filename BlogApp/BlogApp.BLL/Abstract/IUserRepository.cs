﻿using BlogApp.DAL;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.Abstract
{
    public interface IUserRepository : IBaseRepository<User, int, BlogAppContext>
    {
        bool Delete(int id);
    }
}
