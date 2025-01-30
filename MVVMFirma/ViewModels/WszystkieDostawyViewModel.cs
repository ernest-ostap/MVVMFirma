using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieDostawyViewModel : WszystkieViewModel<DostawaForAllView>
    {
        #region Constructor
        public WszystkieDostawyViewModel()
        : base("Dostawy")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data dostawy", "Nazwa dostawcy", "Status dostawy" };
        }

        public override void Sort()
        {
            if (SortField == "Data dostawy")
            {
                List = new ObservableCollection<DostawaForAllView>
                (List.OrderBy(item => item.DataDostawy));
            }
            if (SortField == "Nazwa dostawcy")
            {
                List = new ObservableCollection<DostawaForAllView>
                (List.OrderBy(item => item.NazwaDostawcy));
            }
            if (SortField == "Status dostawy")
            {
                List = new ObservableCollection<DostawaForAllView>
                (List.OrderBy(item => item.StatusDostawy));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data dostawy", "Nazwa dostawcy" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Data dostawy")
                {
                    List = new ObservableCollection<DostawaForAllView>
                    (
                        from dostawa in hurtowniaEntities.Dostawy
                        where dostawa.DataDostawy.ToString().Contains(FindTextBox)
                        select new DostawaForAllView
                        {
                            IdDostawy = dostawa.IdDostawy,
                            DataDostawy = dostawa.DataDostawy,
                            NazwaDostawcy = dostawa.DostawcyProduktow.Nazwa,
                            StatusDostawy = dostawa.Status
                        }
                      );
                }
                if (FindField == "Nazwa dostawcy")
                {
                    List = new ObservableCollection<DostawaForAllView>
                    (
                        from dostawa in hurtowniaEntities.Dostawy
                        where dostawa.DostawcyProduktow.Nazwa.Contains(FindTextBox)
                        select new DostawaForAllView
                        {
                            IdDostawy = dostawa.IdDostawy,
                            DataDostawy = dostawa.DataDostawy,
                            NazwaDostawcy = dostawa.DostawcyProduktow.Nazwa,
                            StatusDostawy = dostawa.Status
                        }
                    );
                }
            }
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DostawaForAllView>
            (
                from dostawa in hurtowniaEntities.Dostawy
                select new DostawaForAllView
                {
                    IdDostawy = dostawa.IdDostawy,
                    DataDostawy = dostawa.DataDostawy,
                    NazwaDostawcy = dostawa.DostawcyProduktow.Nazwa,
                    StatusDostawy = dostawa.Status
                }
            );
        }
        #endregion
    }
}
