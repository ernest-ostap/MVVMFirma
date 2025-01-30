using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ProduktForAllView
    {
        public int IdProduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public string NazwaKategorii { get; set; }
        public string NazwaDostawcy { get; set; }
        public decimal? CenaZakupu { get; set; }
        public decimal? CenaSprzedazy { get; set; }
        public decimal? Ilosc { get; set; }
    }
}
