using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Entities;

namespace Task25.DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {

        IRepository<T> GetRepo<T>() where T : BaseEntity;
        void Save();

    }
}
