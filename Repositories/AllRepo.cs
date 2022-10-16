using Microsoft.EntityFrameworkCore;
using New.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace New.Repositories
{
    public class AllRepo<T> : IAllRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> dbSet;

        public AllRepo(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();

        }

        public  IEnumerable<T> GetAll()
        {
            var rowList =  dbSet.ToList();
            return rowList;
        }

        //public IEnumerable<T> GetAll2()
        //{
        //    var rowList = dbSet.ToList();
        //    rowList = rowList.AsEnumerable().Where(u=>u.)
        //    return rowList;
        //}

        public virtual IEnumerable<T> Get(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
         }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
            _context.SaveChanges();
        }
        
        public void Update(T obj)
        {

            //_context.Update(periodeKaSKPD);
            //await _context.SaveChangesAsync();

            dbSet.Update(obj);
            _context.SaveChanges();
            //_context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {

            //var jabatan = await _context.Jabatan.FindAsync(id);
            //_context.Jabatan.Remove(jabatan);
            //await _context.SaveChangesAsync();

            T entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
            _context.SaveChanges();
            //Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }


        //public int GetNewInt(T obj, object id)
        //{
        //    var row = orderBy(dbSet);.
        //    var row = dbSet.OrderByDescending(u => u.id).Take(1).FirstOrDefault;

        //    return dbSet.Find(id);
        //}

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }


    }
}
