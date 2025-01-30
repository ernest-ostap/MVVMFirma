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
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowienieForAllView>
    {
        #region Constructor
        public WszystkieZamowieniaViewModel()
        : base("Zamowienia")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get;  set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data zamowienia", "Nazwa dostawcy", "Status zamowienia" };
        }

        public override void Sort()
        {
            if (SortField == "Data zamowienia")
            {
                List = new ObservableCollection<ZamowienieForAllView>
                (List.OrderBy(item => item.DataZamowienia));
            }
            if (SortField == "Nazwa dostawcy")
            {
                List = new ObservableCollection<ZamowienieForAllView>
                (List.OrderBy(item => item.NazwaDostawcy));
            }
            if (SortField == "Status zamowienia")
            {
                List = new ObservableCollection<ZamowienieForAllView>
                (List.OrderBy(item => item.StatusZamowienia));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data zamowienia", "Nazwa dostawcy" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Data zamowienia")
                {
                    List = new ObservableCollection<ZamowienieForAllView>
                    (
                        from zamowienie in hurtowniaEntities.Zamowienia
                        where zamowienie.DataZamowienia.ToString().Contains(FindTextBox)
                        select new ZamowienieForAllView
                        {
                            IdZamowienia = zamowienie.IdZamowienia,
                            DataZamowienia = zamowienie.DataZamowienia,
                            NazwaDostawcy = zamowienie.DostawcyProduktow.Nazwa,
                            StatusZamowienia = zamowienie.StatusZamowienia
                        }
                    );
                }
                if (FindField == "Nazwa dostawcy")
                {
                    List = new ObservableCollection<ZamowienieForAllView>
                    (
                        from zamowienie in hurtowniaEntities.Zamowienia
                        where zamowienie.DostawcyProduktow.Nazwa.Contains(FindTextBox)
                        select new ZamowienieForAllView
                        {
                            IdZamowienia = zamowienie.IdZamowienia,
                            DataZamowienia = zamowienie.DataZamowienia,
                            NazwaDostawcy = zamowienie.DostawcyProduktow.Nazwa,
                            StatusZamowienia = zamowienie.StatusZamowienia
                        }
                    );
                }
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowienieForAllView>
            (
                from zamowienie in hurtowniaEntities.Zamowienia
                select new ZamowienieForAllView
                {
                    IdZamowienia = zamowienie.IdZamowienia,
                    DataZamowienia = zamowienie.DataZamowienia,
                    NazwaDostawcy = zamowienie.DostawcyProduktow.Nazwa,
                    StatusZamowienia = zamowienie.StatusZamowienia
                }
            );
        }
        #endregion
    }
}
