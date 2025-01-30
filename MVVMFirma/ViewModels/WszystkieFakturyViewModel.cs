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
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        private string ostatniaWiadomosc = "";
        public WszystkieFakturyViewModel()
        : base("Faktury")
        {
            Messenger.Default.Register<string>(this, "dofaktury", wiadomosc);
        }
        void wiadomosc(string message)
        {
            ostatniaWiadomosc = message;
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer faktury", "Data wystawienia", "Nazwa klienta", "Czy zatwierdzona" };
        }

        public override void Sort()
        {
            if (SortField == "Numer faktury")
            {
                List = new ObservableCollection<FakturaForAllView>
                (List.OrderBy(item => item.NumerFaktury));
            }
            if (SortField == "Data wystawienia")
            {
                List = new ObservableCollection<FakturaForAllView>
                (List.OrderBy(item => item.DataWystawienia));
            }
            if (SortField == "Nazwa klienta")
            {
                List = new ObservableCollection<FakturaForAllView>
                (List.OrderBy(item => item.NazwaKlienta));
            }
            if (SortField == "Czy zatwierdzona")
            {
                List = new ObservableCollection<FakturaForAllView>
                (List.OrderBy(item => item.CzyZatwierdzona));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> {"Numer faktury", "Data wystawienia", "Nazwa klienta" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Numer faktury")
                {
                    List = new ObservableCollection<FakturaForAllView>
                    (from faktura in hurtowniaEntities.Faktury
                     where faktura.Numer.ToString().Contains(FindTextBox)
                     select new FakturaForAllView
                     {
                         IdFaktury = faktura.IdFaktury,
                         NumerFaktury = faktura.Numer,
                         NazwaKlienta = faktura.Klienci.Nazwa,
                         DataWystawienia = faktura.DataWystawienia,
                         CzyZatwierdzona = faktura.CzyZatwierdzona
                     }
                    );
                }
                if (FindField == "Data wystawienia")
                {
                    List = new ObservableCollection<FakturaForAllView>
                    (from faktura in hurtowniaEntities.Faktury
                     where faktura.DataWystawienia.ToString().Contains(FindTextBox)
                     select new FakturaForAllView
                     {
                         IdFaktury = faktura.IdFaktury,
                         NumerFaktury = faktura.Numer,
                         NazwaKlienta = faktura.Klienci.Nazwa,
                         DataWystawienia = faktura.DataWystawienia,
                         CzyZatwierdzona = faktura.CzyZatwierdzona
                     }
                    );
                }
                if (FindField == "Nazwa klienta")
                {
                    List = new ObservableCollection<FakturaForAllView>
                    (from faktura in hurtowniaEntities.Faktury
                     where faktura.Klienci.Nazwa.Contains(FindTextBox)
                     select new FakturaForAllView
                     {
                         IdFaktury = faktura.IdFaktury,
                         NumerFaktury = faktura.Numer,
                         NazwaKlienta = faktura.Klienci.Nazwa,
                         DataWystawienia = faktura.DataWystawienia,
                         CzyZatwierdzona = faktura.CzyZatwierdzona
                     }
                    );
                }
            }
        }

        #endregion

        #region Properties
        //ten propertis bedzie przypisywal sobie to co klikniemy w liscie
        private FakturaForAllView _WybranaFaktura;
        public FakturaForAllView WybranaFaktura
        {
            get { return _WybranaFaktura; }
            set
            {
                _WybranaFaktura = value;
                switch (ostatniaWiadomosc)
                {
                    case ("Platnosc"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doPlatnosci");
                        Messenger.Default.Send(_WybranaFaktura, "itemDoPlatnosci");
                        OnRequestClose();
                        break;
                    case ("PozycjaFaktury"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doPozycjiFaktury");
                        Messenger.Default.Send(_WybranaFaktura, "itemDoPozycjiFaktury");
                        OnRequestClose();
                        break;
                    case ("Zwrot"):
                        Messenger.Default.Send<string>(ostatniaWiadomosc, "doZwrotu");
                        Messenger.Default.Send(_WybranaFaktura, "itemDoZwrotu");
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
            List = new ObservableCollection<FakturaForAllView>
            (
                from faktura in hurtowniaEntities.Faktury
                select new FakturaForAllView
                {
                    IdFaktury = faktura.IdFaktury,
                    NumerFaktury = faktura.Numer,
                    NazwaKlienta = faktura.Klienci.Nazwa,
                    DataWystawienia = faktura.DataWystawienia,
                    CzyZatwierdzona = faktura.CzyZatwierdzona
                }
            );
        }
        #endregion
    }
}
