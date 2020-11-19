using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;

namespace Task25.BLL.Infrustructure.Compare
{
    class TegDTOCompare : IEqualityComparer<TegDTO>
    {
        public bool Equals(TegDTO x, TegDTO y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            if (x?.Name == y?.Name) return true;

            return false;
        }

        public int GetHashCode(TegDTO obj)
        {
            return 111111;
        }
    }
}
