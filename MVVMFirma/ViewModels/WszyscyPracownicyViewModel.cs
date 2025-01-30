using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownicy>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
        :base("Pracownicy")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie", "Nazwisko", "Stanowisko", "Placa", "Rodzaj umowy" };
        }

        public override void Sort()
        {
            if (SortField == "Imie")
            {
                List = new ObservableCollection<Pracownicy>
                (List.OrderBy(item => item.Imie));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<Pracownicy>
                (List.OrderBy(item => item.Nazwisko));
            }
            if (SortField == "Stanowisko")
            {
                List = new ObservableCollection<Pracownicy>
                (List.OrderBy(item => item.Stanowisko));
            }
            if (SortField == "Placa")
            {
                List = new ObservableCollection<Pracownicy>
                (List.OrderBy(item => item.Placa));
            }
            if (SortField == "Rodzaj umowy")
            {
                List = new ObservableCollection<Pracownicy>
                (List.OrderBy(item => item.RodzajUmowy));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imie", "Nazwisko", "Stanowisko", "Rodzaj umowy" };
        }

        public override void Find()
        {
            if (FindField == "Imie")
            {
                List = new ObservableCollection<Pracownicy>
                (List.Where(item => item.Imie.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<Pracownicy>
                (List.Where(item => item.Nazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Stanowisko")
            {
                List = new ObservableCollection<Pracownicy>
                (List.Where(item => item.Stanowisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Rodzaj umowy")
            {
                List = new ObservableCollection<Pracownicy>
                (List.Where(item => item.RodzajUmowy.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List= new ObservableCollection<Pracownicy>
            (hurtowniaEntities.Pracownicy.ToList());
        }
        #endregion
    }
}
