using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NoweWydanieViewModel:JedenViewModel<Wydania>
    {
        #region Konstruktor
        public NoweWydanieViewModel()
        : base("Nowe wydanie")
        {
            item = new Wydania();
        }
        #endregion

        #region Properties
        public DateTime? DataWydania
        {
            get { return item.DataWydania; }
            set
            {
                item.DataWydania = value;
                OnPropertyChanged(() => DataWydania);
            }
        }

        public int? IdKlienta
        {
            get { return item.IdKlienta; }
            set
            {
                item.IdKlienta = value;
                OnPropertyChanged(() => IdKlienta);
            }
        }

        public string Transport
        {
            get { return item.Transport; }
            set
            {
                item.Transport = value;
                OnPropertyChanged(() => Transport);
            }
        }

        #endregion

        #region Wlasciwosci dla comboboxa
        public IQueryable<KeyAndValue> KlienciComboBoxItems
        {
            get 
            {
                return new KlienciB(hurtowniaEntities).GetKlienciKeyAndValueItems();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Wydania.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
