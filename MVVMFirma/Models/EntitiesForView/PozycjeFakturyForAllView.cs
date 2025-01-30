using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjeFakturyForAllView
    {
        public int IdPozycjiFaktury { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaTowaru { get; set; }
        public decimal? Ilosc { get; set; }
    }
}
