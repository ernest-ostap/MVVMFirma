using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class WydaniaForAllView
    {
        public int IdWydania { get; set; }
        public DateTime? DataWydania { get; set; }
        public string NazwaKlienta { get; set; }
        public string Transport { get; set; }
    }
}
