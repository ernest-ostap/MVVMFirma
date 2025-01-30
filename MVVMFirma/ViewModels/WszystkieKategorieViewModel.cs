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
    public class WszystkieKategorieViewModel : WszystkieViewModel<Kategorie>
    {
        #region Constructor
        public WszystkieKategorieViewModel()
        : base("Kategorie")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa kategorii" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa kategorii")
            {
                List = new ObservableCollection<Kategorie>
                (List.OrderBy(item => item.Nazwa));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa kategorii" };
        }

        public override void Find()
        {
            if (FindField == "Nazwa kategorii")
            {
                List = new ObservableCollection<Kategorie>
                (List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Kategorie>
            (hurtowniaEntities.Kategorie.ToList());
        }
        #endregion
    }
}
