using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;

namespace Task25.BLL.Interfaces.IServices
{
    public interface ITegService : IDisposable
    {
        void AddTeg(TegDTO tegDTO);
        TegDTO GetByID(int id);
        void CreateNewTegsIfNotExist(IEnumerable<TegDTO> tegs);
    }
}
