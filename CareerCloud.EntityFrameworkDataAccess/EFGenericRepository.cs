using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private CareerCloudContext _context;

        public EFGenericRepository()
        {
            _context = new CareerCloudContext();
        }

        public void Add(params T[] items)
        {

            foreach (var item in items)
            {
                _context.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            //IQueryable<T> query = _dbSet;

            //foreach(var navigationProperty in navigationProperties)
            //{
            //    query = query.Include(navigationProperty);
            //}
            //return query.ToList();

            throw new NotImplementedException();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            //IQueryable<T> query = _dbSet;

            //foreach (var navigationProperty in navigationProperties)
            //{
            //    query = query.Include(navigationProperty);
            //}
            //return query.Where(where).ToList();

            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navprop in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navprop);
            }
            var result = dbQuery.FirstOrDefault(where);
            _context.Dispose();

            return result;
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }

}

