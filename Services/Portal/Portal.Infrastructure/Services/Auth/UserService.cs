using Microsoft.EntityFrameworkCore;
using Portal.Domain.Aggregates.Auth;
using Portal.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Infrastructure.Services.Auth
{
    public interface IUserService : IDisposable
    {
        List<User> GetAll();

        User GetById(Guid id);

        User Create(User user);

        void Update(User user);

        void Delete(User user);
    }

    public class UserService : IUserService
    {
        private readonly PortalDbContext Context;
        private readonly DbSet<User> DbSet;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            PortalDbContext context,
            IUnitOfWork unitOfWork)
        {
            Context = context;
            DbSet = Context.Set<User>();
            _unitOfWork = unitOfWork;
        }

        public User Create(User user)
        {
            DbSet.Add(user);
            _unitOfWork.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            DbSet.Remove(user);
            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public List<User> GetAll()
        {
            return DbSet.ToList();
        }

        public User GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
            _unitOfWork.SaveChanges();
        }
    }
}