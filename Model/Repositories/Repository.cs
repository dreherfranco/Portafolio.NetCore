using Model.Configuration;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Model.Repository
{
        public class Repository<T> : IRepository<T> where T : class, IEntity
        {
            protected readonly ApplicationContext _context;
            public Repository(ApplicationContext context)
            {
                _context = context;
            }
            public void Add(T entity)
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            public void AddRange(IEnumerable<T> entities)
            {
                _context.Set<T>().AddRange(entities);
            }
            public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
            {
                return _context.Set<T>().Where(expression);
            }

            public IEnumerable<T> GetAll()
            {
                return _context.Set<T>().ToList();
            }
            public T GetById(int id)
            {
                return _context.Set<T>().Find(id);
            }
            public void Update(T entity)
            {
                this._context.Update(entity);
                _context.SaveChanges();
             }
            public void Remove(T entity)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            public void RemoveRange(IEnumerable<T> entities)
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
            }
        }
    
}
