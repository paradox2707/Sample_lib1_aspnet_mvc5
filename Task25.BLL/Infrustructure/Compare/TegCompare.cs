using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Entities;

namespace Task25.BLL.Infrustructure.Compare
{
    public class TegCompare : IEqualityComparer<Teg>
    {
        public bool Equals(Teg x, Teg y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            if (x?.Name == y?.Name) return true;

            return false;
        }

        public int GetHashCode(Teg obj)
        {
            return 111111;
        }
    }
}
