using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ASPdotNETCoreEntityFrameworkWebAPI.DAL
{
    public abstract class GenericDal<T> : IDataLayer<T> where T : class
    {
        protected EJournalContext dbContext;

        public GenericDal(EJournalContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbContext.Find<T>(id);
            if (entity != null)
            {
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> entities = dbContext.Set<T>();
            return entities;
        }

        public T GetById(int id)
        {
            T entity = dbContext.Find<T>(id);
            if(entity != null)
            {
                return entity;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Update(int id, T entity)
        {
            if (dbContext.Find<T>(id) != null)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
