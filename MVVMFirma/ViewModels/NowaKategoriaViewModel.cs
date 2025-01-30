using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaKategoriaViewModel: JedenViewModel<Kategorie>
    {
        #region Konstruktor
        public NowaKategoriaViewModel()
        : base("Nowa kategoria")
        {
            item = new Kategorie();
        }
        #endregion

        #region Properties
        public string Nazwa
        {
            get { return item.Nazwa; }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Kategorie.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
