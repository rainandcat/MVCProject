using Microsoft.EntityFrameworkCore;
using MVCProject.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MVCProject.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private BaseDbContext _db { get; set; }

        public GenericRepository(BaseDbContext db)
        {
            this._db = db;
        }

        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._db.Set<TEntity>().Add(instance);
                this.SaveChanges();
            }

        }

        public void Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            this._db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._db != null)
                {
                    this._db.Dispose();
                    this._db = null;
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this._db.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._db.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllInclude(string instance)
        {
            return this._db.Set<TEntity>().AsQueryable().Include(instance);
        }
    }
}
