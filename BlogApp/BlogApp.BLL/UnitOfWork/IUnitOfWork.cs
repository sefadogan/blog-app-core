using BlogApp.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BLL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        bool Commit();
    }
}
