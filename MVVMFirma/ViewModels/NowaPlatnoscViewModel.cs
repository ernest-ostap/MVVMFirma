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
    public class NowaPlatnoscViewModel : JedenViewModel<Platnosci>
    {
        #region Konstruktor
        public NowaPlatnoscViewModel()
        : base("Nowa płatność")
        {
            item = new Platnosci();
            //messenger oczekujacy na kontrahenta 
            //zamiast czekac na kontrahenta dodaj stringa "WybranyDostawcaDoProduktu", potem wywolaj metode getWybranyDostawca i tam odbierz kontrahenta
            Messenger.Default.Register<string>(this, "doPlatnosci", zOknaModalnego);
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
            Messenger.Default.Send<string>("FakturyAllPlatnosc");
        }

        #endregion

        #region Properties

        public DateTime? DataPlatnosci
        {
            get { return item.DataPlatnosci; }
            set
            {
                item.DataPlatnosci = value;
                OnPropertyChanged(() => DataPlatnosci);
            }
        }
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

        public decimal? Kwota
        {
            get { return item.Kwota; }
            set
            {
                item.Kwota = value;
                OnPropertyChanged(() => Kwota);
            }
        }

        public string MetodaPlatnosci
        {
            get { return item.MetodaPlatnosci; }
            set
            {
                item.MetodaPlatnosci = value;
                OnPropertyChanged(() => MetodaPlatnosci);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Platnosci.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public void zOknaModalnego(string tekst1)
        {
            if (tekst1 == "Platnosc")
            {
                Messenger.Default.Register<FakturaForAllView>(this, "itemDoPlatnosci", getWybranaFaktura);
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

