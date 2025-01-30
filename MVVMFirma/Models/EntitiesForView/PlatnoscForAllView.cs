using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PlatnoscForAllView
    {
        public int IdPlatnosci { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaKlienta { get; set; }
        public DateTime? DataPlatnosci { get; set; }
        public decimal? Kwota { get; set; }
        public string MetodaPlatnosci { get; set; }
    }
}
