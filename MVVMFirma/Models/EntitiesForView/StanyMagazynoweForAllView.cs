using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class StanyMagazynoweForAllView
    {
        public int IdStanuMagazynowego { get; set; }
        public string NazwaProduktu { get; set; }
        public string Kategoria { get; set; }
        public int IdMagazynu { get; set; }
        public string LokalizacjaMagazynu { get; set; }
        public decimal? Ilosc { get; set; }
        
    }
}
