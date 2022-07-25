using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibm_admin.Shared.ViewModels
{
    public class PaginationResultViewModel<T>
    {
        public T Results { get; set; }
        public int ResultsCount { get; set; }
    }
}
