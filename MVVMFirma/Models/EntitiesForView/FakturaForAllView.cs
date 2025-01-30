using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        public int IdFaktury { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaKlienta { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public bool? CzyZatwierdzona { get; set; }
    }
}
