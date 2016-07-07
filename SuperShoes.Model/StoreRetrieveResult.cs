using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Model
{
    public class StoreRetrieveResult:RetrieveResult
    {
        public ICollection<Store> Stores { get; set; }
    }
}
