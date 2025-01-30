using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
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
    public class NowyProduktViewModel : JedenViewModel<Produkty>
    {
        #region Konstruktor
        public NowyProduktViewModel()
        : base("Nowy produkt")
        {
            item = new Produkty();
            //messenger oczekujacy na kontrahenta 
            //zamiast czekac na kontrahenta dodaj stringa "WybranyDostawcaDoProduktu", potem wywolaj metode getWybranyDostawca i tam odbierz kontrahenta
            Messenger.Default.Register<string>(this, "doProduktu", zOknaModalnego);
        }
        #endregion

        #region Command
        private BaseCommand _ShowDostawcy;
        public BaseCommand ShowDostawcy
        {
            get
            {
                if (_ShowDostawcy == null)
                {
                    _ShowDostawcy = new BaseCommand(() => showDostawcy());
                }
                return _ShowDostawcy;
            }
        }

        private void showDostawcy()
        {
            Messenger.Default.Send<string>("DostawcyAllProdukt");
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

        public int? IdDostawcy
        {
            get { return item.IdDostawcy; }
            set
            {
                item.IdDostawcy = value;
                OnPropertyChanged(() => IdDostawcy);
            }
        }

        public string NazwaDostawcy { get; set; }

        public string DostawcaNIP { get; set; }


        public int? IdKategorii
        {
            get { return item.IdKategorii; }
            set
            {
                item.IdKategorii = value;
                OnPropertyChanged(() => IdKategorii);
            }
        }

        public decimal? CenaZakupu
        {
            get { return item.CenaZakupu; }
            set
            {
                item.CenaZakupu = value;
                OnPropertyChanged(() => CenaZakupu);
            }
        }

        public decimal? CenaSprzedazy
        {
            get { return item.CenaSprzedazy; }
            set
            {
                item.CenaSprzedazy = value;
                OnPropertyChanged(() => CenaSprzedazy);
            }
        }

        public decimal? Ilosc
        {
            get { return item.Ilosc; }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }

        #endregion

        #region Wlasciwosci dla comboboxa
        public IQueryable<KeyAndValue> KategorieComboBoxItems
        {
            get
            {
                return new KategorieB(hurtowniaEntities).GetKategorieKeyAndValueItems();
            }
        }
        #endregion



        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Produkty.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public void zOknaModalnego(string tekst1)
        {
            if (tekst1=="Produkt")
            {
                Messenger.Default.Register<DostawcyProduktow>(this, getWybranyDostawca);
            }
        }
        //wywola sie po przeslaniu kontrahenta z listy kontrahentow
        public void getWybranyDostawca(DostawcyProduktow dostawca)
        {
            
            IdDostawcy = dostawca.IdDostawcy;
            NazwaDostawcy = dostawca.Nazwa;
            DostawcaNIP = dostawca.NIP;
        }
        #endregion
    }
}
