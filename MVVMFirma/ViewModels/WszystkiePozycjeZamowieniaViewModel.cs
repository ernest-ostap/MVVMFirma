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
    public class WszystkiePozycjeZamowieniaViewModel : WszystkieViewModel<PozycjeZamowieniaForAllView>
    {
        #region Constructor
        public WszystkiePozycjeZamowieniaViewModel()
        : base("Pozycje zamowienia")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Id zamowienia", "Nazwa produktu", "Ilosc" };
        }

        public override void Sort()
        {
            if (SortField == "Id zamowienia")
            {
                List = new ObservableCollection<PozycjeZamowieniaForAllView>
                (List.OrderBy(item => item.IdZamowienia));
            }
            if (SortField == "Nazwa produktu")
            {
                List = new ObservableCollection<PozycjeZamowieniaForAllView>
                (List.OrderBy(item => item.NazwaProduktu));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<PozycjeZamowieniaForAllView>
                (List.OrderBy(item => item.Ilosc));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Id zamowienia", "Nazwa produktu" };
        }

        public override void Find()
        {
            if (FindField == "Id zamowienia")
            {
                List = new ObservableCollection<PozycjeZamowieniaForAllView>
                (
                    from pozycja in hurtowniaEntities.PozycjeZamowienia
                    where pozycja.Zamowienia.IdZamowienia.ToString().Contains(FindTextBox)
                    select new PozycjeZamowieniaForAllView
                    {
                        IdPozycjiZamowienia = pozycja.IdPozycjiZamowienia,
                        IdZamowienia = pozycja.Zamowienia.IdZamowienia,
                        NazwaProduktu = pozycja.Produkty.Nazwa,
                        Ilosc = pozycja.Ilosc
                    }
                );
            }
            if (FindField == "Nazwa produktu")
            {
                List = new ObservableCollection<PozycjeZamowieniaForAllView>
                (
                    from pozycja in hurtowniaEntities.PozycjeZamowienia
                    where pozycja.Produkty.Nazwa.Contains(FindTextBox)
                    select new PozycjeZamowieniaForAllView
                    {
                        IdPozycjiZamowienia = pozycja.IdPozycjiZamowienia,
                        IdZamowienia = pozycja.Zamowienia.IdZamowienia,
                        NazwaProduktu = pozycja.Produkty.Nazwa,
                        Ilosc = pozycja.Ilosc
                    }
                );
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PozycjeZamowieniaForAllView>
            (
                from pozycja in hurtowniaEntities.PozycjeZamowienia
                select new PozycjeZamowieniaForAllView
                {
                    IdPozycjiZamowienia = pozycja.IdPozycjiZamowienia,
                    IdZamowienia = pozycja.Zamowienia.IdZamowienia,
                    NazwaProduktu = pozycja.Produkty.Nazwa,
                    Ilosc = pozycja.Ilosc
                }
            );
        }
        #endregion
    }
}
