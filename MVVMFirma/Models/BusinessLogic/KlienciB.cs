using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KlienciB:DatabaseClass
    {
        #region Konstruktor
        public KlienciB(HurtowniaEntities2 db)
        : base (db) { }
        #endregion

        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetKlienciKeyAndValueItems()
        {
            return
                (
                    from klient in db.Klienci
                    select new KeyAndValue
                    {
                        Key = klient.IdKlienta,
                        Value = klient.Nazwa + " " + klient.NIP
                    }
                ).ToList().AsQueryable();
        }

        #endregion
    }
}
