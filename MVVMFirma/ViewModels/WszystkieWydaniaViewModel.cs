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
    public class WszystkieWydaniaViewModel : WszystkieViewModel<WydaniaForAllView>
    {
        #region Constructor
        public WszystkieWydaniaViewModel()
        : base("Wydania")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data wydania", "Nazwa klienta", "Transport" };
        }

        public override void Sort()
        {
            if (SortField == "Data wydania")
            {
                List = new ObservableCollection<WydaniaForAllView>
                (List.OrderBy(item => item.DataWydania));
            }
            if (SortField == "Nazwa klienta")
            {
                List = new ObservableCollection<WydaniaForAllView>
                (List.OrderBy(item => item.NazwaKlienta));
            }
            if (SortField == "Transport")
            {
                List = new ObservableCollection<WydaniaForAllView>
                (List.OrderBy(item => item.Transport));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data wydania", "Nazwa klienta", "Transport" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Data wydania")
                {
                    List = new ObservableCollection<WydaniaForAllView>
                    (
                        from wydanie in hurtowniaEntities.Wydania
                        where wydanie.DataWydania.ToString().Contains(FindTextBox)
                        select new WydaniaForAllView
                        {
                            IdWydania = wydanie.IdWydania,
                            DataWydania = wydanie.DataWydania,
                            NazwaKlienta = wydanie.Klienci.Nazwa,
                            Transport = wydanie.Transport
                        }
                    );
                }
                if (FindField == "Nazwa klienta")
                {
                    List = new ObservableCollection<WydaniaForAllView>
                    (
                        from wydanie in hurtowniaEntities.Wydania
                        where wydanie.Klienci.Nazwa.Contains(FindTextBox)
                        select new WydaniaForAllView
                        {
                            IdWydania = wydanie.IdWydania,
                            DataWydania = wydanie.DataWydania,
                            NazwaKlienta = wydanie.Klienci.Nazwa,
                            Transport = wydanie.Transport
                        }
                    );
                }
                if (FindField == "Transport")
                {
                    List = new ObservableCollection<WydaniaForAllView>
                    (
                        from wydanie in hurtowniaEntities.Wydania
                        where wydanie.Transport.Contains(FindTextBox)
                        select new WydaniaForAllView
                        {
                            IdWydania = wydanie.IdWydania,
                            DataWydania = wydanie.DataWydania,
                            NazwaKlienta = wydanie.Klienci.Nazwa,
                            Transport = wydanie.Transport
                        }
                    );
                }
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WydaniaForAllView>
            (
                from wydanie in hurtowniaEntities.Wydania
                select new WydaniaForAllView
                {
                    IdWydania = wydanie.IdWydania,
                    DataWydania = wydanie.DataWydania,
                    NazwaKlienta = wydanie.Klienci.Nazwa,
                    Transport = wydanie.Transport
                }
            );
        }
        #endregion
    }
}
