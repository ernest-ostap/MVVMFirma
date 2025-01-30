using GalaSoft.MvvmLight.Messaging;
using global::MVVMFirma.Helper;
using global::MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace MVVMFirma.ViewModels
{
    public class NowyZwrotViewModel : JedenViewModel<Zwroty>
    {
        #region Konstruktor
        public NowyZwrotViewModel()
        : base("Nowy zwrot")
        {
            item = new Zwroty();
            //messenger oczekujacy na kontrahenta 
            //zamiast czekac na kontrahenta dodaj stringa "WybranyDostawcaDoProduktu", potem wywolaj metode getWybranyDostawca i tam odbierz kontrahenta
            Messenger.Default.Register<string>(this, "doZwrotu", zOknaModalnego);
        }
        #endregion

        #region Command
        private BaseCommand _ShowFaktury;
        public BaseCommand ShowFaktury
        {
            get
            {
                if (_ShowFaktury == null)
                {
                    _ShowFaktury = new BaseCommand(() => showFaktury());
                }
                return _ShowFaktury;
            }
        }

        private void showFaktury()
        {
            Messenger.Default.Send<string>("FakturyAllZwrot");
        }

        #endregion

        #region Properties


        public int? IdFaktury
        {
            get { return item.IdFaktury; }
            set
            {
                item.IdFaktury = value;
                OnPropertyChanged(() => IdFaktury);
            }
        }

        public string NumerFaktury { get; set; }

        public int? IdProduktu
        {
            get { return item.IdProduktu; }
            set
            {
                item.IdProduktu = value;
                OnPropertyChanged(() => IdProduktu);
            }
        }

        public decimal? Ilosc
        {
            get { return item.Ilość; }
            set
            {
                item.Ilość = value;
                OnPropertyChanged(() => Ilosc);
            }
        }

        public DateTime? DataZwrotu
        {
            get { return item.DataZwrotu; }
            set
            {
                item.DataZwrotu = value;
                OnPropertyChanged(() => DataZwrotu);
            }
        }

        #endregion

        #region Wlasciwosci dla comboboxa
        public IQueryable<KeyAndValue> ProduktyComboBoxItems
        {
            get
            {
                return new ProduktyB(hurtowniaEntities).GetProduktyKeyAndValue();
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Zwroty.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public void zOknaModalnego(string tekst1)
        {
            if (tekst1 == "Zwrot")
            {
                Messenger.Default.Register<FakturaForAllView>(this, "itemDoZwrotu", getWybranaFaktura);
            }
        }
        //wywola sie po przeslaniu kontrahenta z listy kontrahentow
        public void getWybranaFaktura(FakturaForAllView faktura)
        {
            IdFaktury = faktura.IdFaktury;
            NumerFaktury = faktura.NumerFaktury;
        }
        #endregion
    }
}

