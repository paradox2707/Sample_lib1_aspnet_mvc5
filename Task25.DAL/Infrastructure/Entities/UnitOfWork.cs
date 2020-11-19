using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Data;
using Task25.DAL.Infrastructure.Interfaces;
using Task25.DAL.Entities;

namespace Task25.DAL.Infrastructure.Entities
{
    public class UnitOfWork: IUnitOfWork
    {
        readonly AppDBContext context;
        readonly Dictionary<Type, object> repos;

        public UnitOfWork(string connectionString) //AppDBContext dbcontext
        {
            this.context = new AppDBContext(connectionString);//dbcontext;
            this.repos = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepo<T>() where T : BaseEntity
        {
            if(repos.Keys.Contains(typeof(T)))
            {
                return repos[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(context);
            repos.Add(typeof(T), repo);

            return repo;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support  
        private bool _disposedValue = false; // To detect redundant calls  

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                //dispose managed state (managed objects).  
                context.Dispose();
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.  
            // set large fields to null.  

            _disposedValue = true;
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.  
        // ~UnitOfWork() {  
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
        //   Dispose(false);  
        // }  

        // This code added to correctly implement the disposable pattern.  
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.  
             GC.SuppressFinalize(this);  
        }
        #endregion
    }
}
