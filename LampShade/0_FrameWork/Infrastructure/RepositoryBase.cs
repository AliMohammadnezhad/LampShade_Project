using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _0_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_FrameWork.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}