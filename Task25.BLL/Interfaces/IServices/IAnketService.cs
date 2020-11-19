using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;

namespace Task25.BLL.Interfaces.IServices
{
    public interface IAnketService: IDisposable
    {
        AnketDTO GetAnketByName(string name);
        void AddResponse(AnketResponseDTO responseDTO);
    }
}
