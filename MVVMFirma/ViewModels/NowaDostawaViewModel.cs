using GalaSoft.MvvmLight.Messaging;
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
    public class NowaDostawaViewModel : JedenViewModel<Dostawy>
    {
        #region Konstruktor
        public NowaDostawaViewModel()
        : base("Nowa dostawa")
        {
            item = new Dostawy();
            //messenger oczekujacy na kontrahenta 
            //zamiast czekac na kontrahenta dodaj stringa "WybranyDostawcaDoProduktu", potem wywolaj metode getWybranyDostawca i tam odbierz kontrahenta
            Messenger.Default.Register<string>(this, "doDostawy", zOknaModalnego);
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
            Messenger.Default.Send<string>("DostawcyAllDostawa");
        }

        #endregion

        #region Properties

        public DateTime? DataDostawy 
        {
            get { return item.DataDostawy; }
            set
            {
                item.DataDostawy = value;
                OnPropertyChanged(() => DataDostawy);
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

        public Boolean? Status
        {
            get { return item.Status; }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => DataDostawy);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            hurtowniaEntities.Dostawy.Add(item); //dodaje towar do lokalnej kolekcji 
            hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public void zOknaModalnego(string tekst1)
        {
            if (tekst1 == "Dostawa")
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
