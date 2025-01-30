using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyDostawcaViewModel : JedenViewModel<DostawcyProduktow>
    {
        #region Konstruktor
        public NowyDostawcaViewModel()
        : base("Nowy dostawca")
        {
            item = new DostawcyProduktow();
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

        public string NIP
        {
            get { return item.NIP; }
            set
            {
                item.NIP = value;
                OnPropertyChanged(() => NIP);
            }
        }

        public string Adres
        {
            get { return item.Adres; }
            set
            {
                item.Adres = value;
                OnPropertyChanged(() => Adres);
            }
        }

        public string Telefon
        {
            get { return item.Telefon; }
            set
            {
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }

        public string Email
        {
            get { return item.Email; }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.DostawcyProduktow.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
