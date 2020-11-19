using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Data;
using Task25.DAL.Infrastructure.Interfaces;
using Task25.DAL.Entities;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace Task25.DAL.Infrastructure.Entities
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private AppDBContext db;
        readonly DbSet<T> dbSet;

        public Repository(AppDBContext dbContext)
        {
            this.db = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
            //return dbSet.AsNoTracking().ToList();

            //var list = dbSet.ToList();
            //db.Entry(list).State = EntityState.Detached;
            //return list;
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
            //return dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual void Update(T entity) //, params string[] props
        {

            //T existing = dbSet.Find(entity.Id);
            //if (existing != null)
            //{
            //    db.Entry(existing).CurrentValues.SetValues(entity);
            //}

            //var local = dbSet.FirstOrDefault(f => f.Id == entity.Id);
            //if (local != null)
            //{
            //    db.Entry(local).State = EntityState.Detached;
            //}


            //dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            //foreach (var prop in props)
            //{
            //    db.Entry(entity).Collection(prop).Load();
            //    dynamic many = db.Entry(entity).Collection(prop).CurrentValue;
            //    db.Entry(many[0]).State = EntityState.Unchanged; 

            //}

            //db.ChangeTracker.Entries();            
            //dbSet.AddOrUpdate(entity);


            //DbEntityEntry dbEntityEntry = db.Entry(entity);
            //if (dbEntityEntry.State == EntityState.Detached)
            //{
            //    var pkey = dbSet.Create().GetType().GetProperty("Id").GetValue(entity);//assuming Id is the key column
            //    var set = db.Set<T>();
            //    T attachedEntity = set.Find(pkey);
            //    if (attachedEntity != null)
            //    {
            //        var attachedEntry = db.Entry(attachedEntity);
            //        attachedEntry.CurrentValues.SetValues(entity);
            //    }
            //}


            //dbSet.AddOrUpdate(x => x.Id, entity);


            //var local = dbSet.FirstOrDefault(f => f.Id == entity.Id);
            //if (local != null)
            //{
            //    db.Entry(local).State = EntityState.Detached;
            //    // можливо використати рефлексію і ітерувати кожну властивість, 
            //    // оскільки в мене створюються нові теги, але це вже краще ніж було 
            //    //оскільки проміжна таблиця генерує звязки між articles and tags 

            //}
            //dbSet.Add(entity);
            //db.Entry(entity).State = EntityState.Modified;

            //var entry = db.Entry(entity);

            //if (entry.State == EntityState.Detached)
            //{
            //    T attachedEntity = dbSet.Find(entity.Id);

            //    // You need to have access to key
            //    if ((attachedEntity != null))
            //    {
            //        var attachedEntry = db.Entry(attachedEntity);
            //        attachedEntry.CurrentValues.SetValues(entity);

            //    }
            //    else
            //    {
            //        // This should attach entity
            //        entry.State = EntityState.Modified;
            //    }
            //}


            //var test = dbSet.Find(entity.Id);
        }


        public virtual void Delete(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
                dbSet.Remove(entity);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
