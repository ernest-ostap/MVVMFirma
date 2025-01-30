using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyMagazynViewModel : JedenViewModel<Magazyny>
    {
        #region Konstruktor
        public NowyMagazynViewModel()
        : base("Nowy Magazyn")
        {
            item = new Magazyny();
        }
        #endregion

        #region Properties
        public string Lokalizacja
        {
            get { return item.Lokalizacja; }
            set
            {
                item.Lokalizacja = value;
                OnPropertyChanged(() => Lokalizacja);
            }
        }

        public decimal? Wielkosc
        {
            get { return item.Wielkosc; }
            set
            {
                item.Wielkosc = value;
                OnPropertyChanged(() => Wielkosc);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Magazyny.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
