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
    /// <summary>Entity for access to responses db context</summary>
    public class ResponseRepository //: IRepository<AnketResponse>
    {

        /// <summary>The database
        /// context</summary>
        private AppDBContext db;

        /// <summary>Initializes a new instance of the <see cref="ResponseRepository" /> class.</summary>
        public ResponseRepository(AppDBContext dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>Creates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public void Create(AnketResponse entity)
        {
            db.AnketResponses.Add(entity);
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            AnketResponse response = db.AnketResponses.Find(id);
            if (response != null)
                db.AnketResponses.Remove(response);
        }

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<AnketResponse> GetAll()
        {
            return db.AnketResponses;
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public AnketResponse GetById(int id)
        {
            return db.AnketResponses.Find(id);
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public void Update(AnketResponse entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>Saves this instance.</summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>The disposed</summary>
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
