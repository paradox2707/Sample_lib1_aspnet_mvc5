using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Data;
using Task25.DAL.Infrastructure.Interfaces;
using Task25.DAL.Entities;

namespace Task25.DAL.Infrastructure.Entities
{
    /// <summary>Entity for access to ankets db context</summary>
    public class AnketRepository //: IRepository<Anket>
    {
        /// <summary>The database
        /// context</summary>
        private AppDBContext db;

        /// <summary>Initializes a new instance of the <see cref="AnketRepository" /> class.</summary>
        public AnketRepository(AppDBContext dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>Creates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public void Create(Anket entity)
        {
            db.Ankets.Add(entity);
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            Anket anket = db.Ankets.Find(id);
            if (anket != null)
                db.Ankets.Remove(anket);
        }

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<Anket> GetAll()
        {
            return db.Ankets;
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Anket GetById(int id)
        {
            return db.Ankets.Find(id);
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public void Update(Anket entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>Saves this instance.</summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>The disposed
        /// state</summary>
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
