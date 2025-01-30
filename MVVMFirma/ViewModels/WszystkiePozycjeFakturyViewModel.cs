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
    public class WszystkiePozycjeFakturyViewModel : WszystkieViewModel<PozycjeFakturyForAllView>
    {
        #region Constructor
        public WszystkiePozycjeFakturyViewModel()
        : base("Pozycje faktury")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer faktury", "Nazwa towaru", "Ilosc" };
        }

        public override void Sort()
        {
            if (SortField == "Numer faktury")
            {
                List = new ObservableCollection<PozycjeFakturyForAllView>
                (List.OrderBy(item => item.NumerFaktury));
            }
            if (SortField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjeFakturyForAllView>
                (List.OrderBy(item => item.NazwaTowaru));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<PozycjeFakturyForAllView>
                (List.OrderBy(item => item.Ilosc));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Numer faktury", "Nazwa towaru" };
        }

        public override void Find()
        {
            if (FindField == "Numer faktury")
            {
                List = new ObservableCollection<PozycjeFakturyForAllView>
                (
                    from pozycjaFaktury in hurtowniaEntities.PozycjeFaktury
                    where pozycjaFaktury.Faktury.Numer.Contains(FindTextBox)
                    select new PozycjeFakturyForAllView
                    {
                        IdPozycjiFaktury = pozycjaFaktury.IdPozycjiFaktury,
                        NumerFaktury = pozycjaFaktury.Faktury.Numer,
                        NazwaTowaru = pozycjaFaktury.Produkty.Nazwa,
                        Ilosc = pozycjaFaktury.Ilosc
                    }
                );
            }
            if (FindField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjeFakturyForAllView>
                (
                    from pozycjaFaktury in hurtowniaEntities.PozycjeFaktury
                    where pozycjaFaktury.Produkty.Nazwa.Contains(FindTextBox)
                    select new PozycjeFakturyForAllView
                    {
                        IdPozycjiFaktury = pozycjaFaktury.IdPozycjiFaktury,
                        NumerFaktury = pozycjaFaktury.Faktury.Numer,
                        NazwaTowaru = pozycjaFaktury.Produkty.Nazwa,
                        Ilosc = pozycjaFaktury.Ilosc
                    }
                 );
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PozycjeFakturyForAllView>
            (
                from pozycjaFaktury in hurtowniaEntities.PozycjeFaktury
                select new PozycjeFakturyForAllView
                {
                    IdPozycjiFaktury = pozycjaFaktury.IdPozycjiFaktury,
                    NumerFaktury = pozycjaFaktury.Faktury.Numer,
                    NazwaTowaru = pozycjaFaktury.Produkty.Nazwa,
                    Ilosc = pozycjaFaktury.Ilosc
                }
            );
        }
        #endregion
    }
}
