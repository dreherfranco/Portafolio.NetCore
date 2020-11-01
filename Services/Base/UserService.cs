using Model.Entities;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Base
{
    public class UserService
    {
        IRepository<User> Repository;
        public UserService(IRepository<User> repository)
        {
            this.Repository = repository;
        }

        public void Add(User entity)
        {
            this.Repository.Add(entity);
        }
        
        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return this.Repository.Find(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return this.Repository.GetAll();
        }
        public User GetById(int id)
        {
            return this.Repository.GetById(id);
        }
        public void Update(User entity)
        {
            this.Repository.Update(entity);   
        }
        public void Remove(User entity)
        {
            this.Repository.Remove(entity);   
        }
    }
}
