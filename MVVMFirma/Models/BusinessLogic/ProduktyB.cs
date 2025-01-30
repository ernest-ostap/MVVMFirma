using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ProduktyB : DatabaseClass
    {
        #region Konstruktor
        public ProduktyB(HurtowniaEntities2 db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetProduktyKeyAndValue()
        {
            return
                (
                    from produkt in db.Produkty
                    select new KeyAndValue
                    {
                        Key = produkt.IdProduktu,
                        Value = produkt.Nazwa 
                    }
                ).ToList().AsQueryable();
        }

        #endregion
    }
}
