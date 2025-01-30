using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszyscyDostawcyViewModel : WszystkieViewModel<DostawcyProduktow>
    {
        #region Constructor
        private string ostatniaWiadomosc = "";
        public WszyscyDostawcyViewModel()
        : base("Dostawcy")
        {
            Messenger.Default.Register<string>(this, "dodostawcy", wiadomosc); 
        }

        void wiadomosc(string message)
        {
            ostatniaWiadomosc = message;
        }
        #endregion

        #region Sort and Filter
        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "NIP", "Adres", "Telefon", "Email" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.OrderBy(item => item.Nazwa));
            }
            else if (SortField == "NIP")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.OrderBy(item => item.NIP));
            }
            else if (SortField == "Adres")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.OrderBy(item => item.Adres));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.OrderBy(item => item.Email));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "NIP", "Adres", "Telefon", "Email" };
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
            else if (FindField == "NIP")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
            }
            else if (FindField == "Adres")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.Where(item => item.Adres != null && item.Adres.StartsWith(FindTextBox)));
            }
            else if (FindField == "Telefon")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            }
            else if (FindField == "Email")
            {
                List = new ObservableCollection<DostawcyProduktow>
                (List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            }
        }
        #endregion

        #region Properties
        //ten propertis bedzie przypisywal sobie to co klikniemy w liscie
        private DostawcyProduktow _WybranyDostawca;
        public DostawcyProduktow WybranyDostawca
        {
            get { return _WybranyDostawca; }
            set
            {
                _WybranyDostawca = value;
                switch (ostatniaWiadomosc)
                {
                    case ("Produkt"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doProduktu");
                        Messenger.Default.Send(_WybranyDostawca);
                        OnRequestClose();
                        break;
                    case ("Zamowienie"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doZamowienia");
                        Messenger.Default.Send(_WybranyDostawca);
                        OnRequestClose();
                        break;
                    case ("Dostawa"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doDostawy");
                        Messenger.Default.Send(_WybranyDostawca);
                        OnRequestClose();
                        break;
                    default:
                        return;
                }
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DostawcyProduktow>
            (hurtowniaEntities.DostawcyProduktow.ToList());
        }
        #endregion
    }
}
