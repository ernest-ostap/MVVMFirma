using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieMagazynyViewModel : WszystkieViewModel<Magazyny>
    {
        #region Constructor
        public WszystkieMagazynyViewModel()
        : base("Magazyny")
        {
        }
        #endregion

        #region sort and filter
        
        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Adres", "Rozmiar" };
        }

        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<Magazyny>
                (List.OrderBy(item => item.IdMagazynu));
            }
            if (SortField == "Adres")
            {
                List = new ObservableCollection<Magazyny>
                (List.OrderBy(item => item.Lokalizacja));
            }
            if (SortField == "Rozmiar")
            {
                List = new ObservableCollection<Magazyny>
                (List.OrderBy(item => item.Lokalizacja));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ID", "Adres", "Rozmiar" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "ID")
                {
                    List = new ObservableCollection<Magazyny>
                    (List.Where(item => item.IdMagazynu.ToString().Contains(FindTextBox)));
                }
                if (FindField == "Adres")
                {
                    List = new ObservableCollection<Magazyny>
                    (List.Where(item => item.Lokalizacja.Contains(FindTextBox)));
                }
                if (FindField == "Rozmiar")
                {
                    List = new ObservableCollection<Magazyny>
                    (List.Where(item => item.Wielkosc.ToString().Contains(FindTextBox)));
                }
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Magazyny>
            (hurtowniaEntities.Magazyny.ToList());
        }
        #endregion
    }
}
