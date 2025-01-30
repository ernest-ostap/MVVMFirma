using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KategorieB : DatabaseClass
    {
        #region Konstruktor
        public KategorieB(HurtowniaEntities2 db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetKategorieKeyAndValueItems()
        {
            return
                (
                    from kategoria in db.Kategorie
                    select new KeyAndValue
                    {
                        Key = kategoria.IdKategorii,
                        Value = kategoria.Nazwa
                    }
                ).ToList().AsQueryable();
        }

        #endregion
    }
}
