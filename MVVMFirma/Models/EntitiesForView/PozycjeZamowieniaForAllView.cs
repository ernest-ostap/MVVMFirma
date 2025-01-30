using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjeZamowieniaForAllView
    {
        public int IdPozycjiZamowienia { get; set; }
        public int IdZamowienia { get; set; }
        public string NazwaProduktu { get; set; }
        public decimal? Ilosc { get; set; }
    }
}
