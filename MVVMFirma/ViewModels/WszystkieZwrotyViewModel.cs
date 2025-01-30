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
    public class WszystkieZwrotyViewModel : WszystkieViewModel<ZwrotForAllView>
    {
        #region Constructor
        public WszystkieZwrotyViewModel()
        : base("Zwroty")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get;  set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data zwrotu", "Nazwa produktu", "Numer faktury", "Ilosc" };
        }

        public override void Sort()
        {
            if (SortField == "Data zwrotu")
            {
                List = new ObservableCollection<ZwrotForAllView>
                (List.OrderBy(item => item.DataZwrotu));
            }
            if (SortField == "Nazwa produktu")
            {
                List = new ObservableCollection<ZwrotForAllView>
                (List.OrderBy(item => item.NazwaProduktu));
            }
            if (SortField == "Numer faktury")
            {
                List = new ObservableCollection<ZwrotForAllView>
                (List.OrderBy(item => item.NumerFaktury));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<ZwrotForAllView>
                (List.OrderBy(item => item.Ilosc));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data zwrotu", "Nazwa produktu", "Numer faktury" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Data zwrotu")
                {
                    List = new ObservableCollection<ZwrotForAllView>
                    (
                        from zwrot in hurtowniaEntities.Zwroty
                        where zwrot.DataZwrotu.ToString().Contains(FindTextBox)
                        select new ZwrotForAllView
                        {
                            IdZwrotu = zwrot.IdZwrotu,
                            NazwaProduktu = zwrot.Produkty.Nazwa,
                            NumerFaktury = zwrot.Faktury.Numer,
                            DataZwrotu = zwrot.DataZwrotu,
                            Ilosc = zwrot.Ilość
                        }
                    );
                }
                if (FindField == "Nazwa produktu")
                {
                    List = new ObservableCollection<ZwrotForAllView>
                    (
                        from zwrot in hurtowniaEntities.Zwroty
                        where zwrot.Produkty.Nazwa.Contains(FindTextBox)
                        select new ZwrotForAllView
                        {
                            IdZwrotu = zwrot.IdZwrotu,
                            NazwaProduktu = zwrot.Produkty.Nazwa,
                            NumerFaktury = zwrot.Faktury.Numer,
                            DataZwrotu = zwrot.DataZwrotu,
                            Ilosc = zwrot.Ilość
                        }
                    );
                }
                if (FindField == "Numer faktury")
                {
                    List = new ObservableCollection<ZwrotForAllView>
                    (
                        from zwrot in hurtowniaEntities.Zwroty
                        where zwrot.Faktury.Numer.Contains(FindTextBox)
                        select new ZwrotForAllView
                        {
                            IdZwrotu = zwrot.IdZwrotu,
                            NazwaProduktu = zwrot.Produkty.Nazwa,
                            NumerFaktury = zwrot.Faktury.Numer,
                            DataZwrotu = zwrot.DataZwrotu,
                            Ilosc = zwrot.Ilość
                        }
                    );
                }
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZwrotForAllView>
            (
                from zwrot in hurtowniaEntities.Zwroty
                select new ZwrotForAllView
                {
                    IdZwrotu = zwrot.IdZwrotu,
                    NazwaProduktu = zwrot.Produkty.Nazwa,
                    NumerFaktury = zwrot.Faktury.Numer,
                    DataZwrotu = zwrot.DataZwrotu,
                    Ilosc = zwrot.Ilość
                }
            );
        }
        #endregion
    }
}
