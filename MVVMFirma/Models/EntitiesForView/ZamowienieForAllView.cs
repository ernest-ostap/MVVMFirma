using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ZamowienieForAllView
    {
        public int IdZamowienia { get; set; }
        public DateTime? DataZamowienia { get; set; }
        public string NazwaDostawcy { get; set; }
        public string StatusZamowienia { get; set; }


    }
}
