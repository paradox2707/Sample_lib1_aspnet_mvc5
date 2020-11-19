using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Entities;

namespace Task25.DAL.Infrastructure.Interfaces
{
    /// <summary>Interface for access to db context</summary>
    /// <typeparam name="T">TEntity</typeparam>
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        T GetById(int id);
        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<T> GetAll();
        /// <summary>Creates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);
        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);
        /// <summary>Saves this instance.</summary>
        void Save();
    }
}
