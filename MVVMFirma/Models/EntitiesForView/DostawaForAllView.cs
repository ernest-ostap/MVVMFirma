using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DostawaForAllView
    {
        public int IdDostawy { get; set; }
        public DateTime? DataDostawy { get; set; }
        
        //zamiast id dostawcy, bedzie NazwaDostawcy
        public string NazwaDostawcy { get; set; }
        public bool? StatusDostawy { get; set; }
    }
}
