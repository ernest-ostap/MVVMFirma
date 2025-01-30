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
    public class NoweZamowienieViewModel : JedenViewModel<Zamowienia>
    {
        #region Konstruktor
        public NoweZamowienieViewModel()
        : base("Nowe zamowienie")
        {
            item = new Zamowienia();
            //messenger oczekujacy na kontrahenta 
            //zamiast czekac na kontrahenta dodaj stringa "WybranyDostawcaDoProduktu", potem wywolaj metode getWybranyDostawca i tam odbierz kontrahenta
            Messenger.Default.Register<string>(this, "doZamowienia", zOknaModalnego);
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
            Messenger.Default.Send<string>("DostawcyAllZamowienie");
        }

        #endregion

        #region Properties

        public DateTime? DataZamowienia
        {
            get { return item.DataZamowienia; }
            set
            {
                item.DataZamowienia = value;
                OnPropertyChanged(() => DataZamowienia);
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

        public string StatusZamowienia
        {
            get { return item.StatusZamowienia; }
            set
            {
                item.StatusZamowienia = value;
                OnPropertyChanged(() => StatusZamowienia);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Zamowienia.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public void zOknaModalnego(string tekst1)
        {
            if (tekst1 == "Zamowienie")
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

