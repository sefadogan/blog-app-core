using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.BLL.Abstract;
using BlogApp.BLL.Concrete;
using BlogApp.DAL;

namespace BlogApp.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppContext _context;
        private IUserRepository userRepository;
        private IPostRepository postRepository;
        private IRoleRepository roleRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork(BlogAppContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => UserRepository ?? (userRepository = new UserRepository(_context));
        public IPostRepository PostRepository => PostRepository ?? (postRepository = new PostRepository(_context));
        public IRoleRepository RoleRepository => RoleRepository ?? (roleRepository = new RoleRepository(_context));
        public ICategoryRepository CategoryRepository => CategoryRepository ?? (categoryRepository = new CategoryRepository(_context));

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                return true; 
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
