using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTLElectronics.Interfaces;
using HTLElectronics.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace HTLElectronics.DAL.Gateway
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal ApplicationDbContext context;
        internal DbSet<T> dbset;

        public SqlRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbset;
        }

        public void Commit()
        {
            //context.SaveChanges();

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Delete(string Id)
        {
            var t = Find(Id);
            if(context.Entry(t).State == EntityState.Detached)
            {
                dbset.Attach(t);
            }

            dbset.Remove(t);
        }

        public T Find(string Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T t)
        {
            dbset.Add(t);            
        }
        
        public void Update(T t)
        {
            dbset.Attach(t);            
            context.Entry(t).State = EntityState.Modified;
        }
    }
}