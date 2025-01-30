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
    public class WszystkiePlatnosciViewModel : WszystkieViewModel<PlatnoscForAllView>
    {
        #region Constructor
        public WszystkiePlatnosciViewModel()
        : base("Platnosci")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer faktury", "Nazwa klienta", "Data platnosci", "Kwota", "Metoda platnosci" };
        }

        public override void Sort()
        {
            if (SortField == "Numer faktury")
            {
                List = new ObservableCollection<PlatnoscForAllView>
                (List.OrderBy(item => item.NumerFaktury));
            }
            if (SortField == "Nazwa klienta")
            {
                List = new ObservableCollection<PlatnoscForAllView>
                (List.OrderBy(item => item.NazwaKlienta));
            }
            if (SortField == "Data platnosci")
            {
                List = new ObservableCollection<PlatnoscForAllView>
                (List.OrderBy(item => item.DataPlatnosci));
            }
            if (SortField == "Kwota")
            {
                List = new ObservableCollection<PlatnoscForAllView>
                (List.OrderBy(item => item.Kwota));
            }
            if (SortField == "Metoda platnosci")
            {
                List = new ObservableCollection<PlatnoscForAllView>
                (List.OrderBy(item => item.MetodaPlatnosci));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Numer faktury", "Nazwa klienta", "Data platnosci", "Kwota", "Metoda platnosci" };
        }

        public override void Find()
        {
            if(FindTextBox != null)
            {
                if(FindField == "Numer faktury")
                {
                    List = new ObservableCollection<PlatnoscForAllView>
                    (List.Where(item => item.NumerFaktury.Contains(FindTextBox)));
                }
                if (FindField == "Nazwa klienta")
                {
                    List = new ObservableCollection<PlatnoscForAllView>
                    (List.Where(item => item.NazwaKlienta.Contains(FindTextBox)));
                }
                if (FindField == "Data platnosci")
                {
                    List = new ObservableCollection<PlatnoscForAllView>
                    (List.Where(item => item.DataPlatnosci.ToString().Contains(FindTextBox)));
                }
                if (FindField == "Kwota")
                {
                    List = new ObservableCollection<PlatnoscForAllView>
                    (List.Where(item => item.Kwota.ToString().Contains(FindTextBox)));
                }
                if (FindField == "Metoda platnosci")
                {
                    List = new ObservableCollection<PlatnoscForAllView>
                    (List.Where(item => item.MetodaPlatnosci.Contains(FindTextBox)));
                }
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PlatnoscForAllView>
            (
                from platnosc in hurtowniaEntities.Platnosci
                select new PlatnoscForAllView
                {
                    IdPlatnosci = platnosc.IdPlatnosci,
                    NumerFaktury = platnosc.Faktury.Numer,
                    NazwaKlienta = platnosc.Faktury.Klienci.Nazwa,
                    DataPlatnosci = platnosc.DataPlatnosci,
                    Kwota = platnosc.Kwota,
                    MetodaPlatnosci = platnosc.MetodaPlatnosci
                }
            );
        }
        #endregion
    }
}
