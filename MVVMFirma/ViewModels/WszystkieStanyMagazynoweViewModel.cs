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
    public class WszystkieStanyMagazynoweViewModel : WszystkieViewModel<StanyMagazynoweForAllView>
    {
        #region Constructor
        public WszystkieStanyMagazynoweViewModel()
        : base("Stany magazynowe")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa produktu", "Kategoria", "Lokalizacja magazynu", "Ilosc" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa produktu")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (List.OrderBy(item => item.NazwaProduktu));
            }
            if (SortField == "Kategoria")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (List.OrderBy(item => item.Kategoria));
            }
            if (SortField == "Lokalizacja magazynu")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (List.OrderBy(item => item.LokalizacjaMagazynu));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (List.OrderBy(item => item.Ilosc));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa produktu", "Kategoria", "Lokalizacja magazynu" };
        }

        public override void Find()
        {
            if (FindField == "Nazwa produktu")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (
                    from stanMagazynowy in hurtowniaEntities.StanyMagazynowe
                    where stanMagazynowy.Produkty.Nazwa.Contains(FindTextBox)
                    select new StanyMagazynoweForAllView
                    {
                        IdStanuMagazynowego = stanMagazynowy.IdStanuMagazynowego,
                        NazwaProduktu = stanMagazynowy.Produkty.Nazwa,
                        Kategoria = stanMagazynowy.Produkty.Kategorie.Nazwa,
                        IdMagazynu = stanMagazynowy.Magazyny.IdMagazynu,
                        LokalizacjaMagazynu = stanMagazynowy.Magazyny.Lokalizacja,
                        Ilosc = stanMagazynowy.Ilosc
                    }
                );
            }
            if (FindField == "Kategoria")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (
                    from stanMagazynowy in hurtowniaEntities.StanyMagazynowe
                    where stanMagazynowy.Produkty.Kategorie.Nazwa.Contains(FindTextBox)
                    select new StanyMagazynoweForAllView
                    {
                        IdStanuMagazynowego = stanMagazynowy.IdStanuMagazynowego,
                        NazwaProduktu = stanMagazynowy.Produkty.Nazwa,
                        Kategoria = stanMagazynowy.Produkty.Kategorie.Nazwa,
                        IdMagazynu = stanMagazynowy.Magazyny.IdMagazynu,
                        LokalizacjaMagazynu = stanMagazynowy.Magazyny.Lokalizacja,
                        Ilosc = stanMagazynowy.Ilosc
                    }
                );
            }
            if (FindField == "Lokalizacja magazynu")
            {
                List = new ObservableCollection<StanyMagazynoweForAllView>
                (
                    from stanMagazynowy in hurtowniaEntities.StanyMagazynowe
                    where stanMagazynowy.Magazyny.Lokalizacja.Contains(FindTextBox)
                    select new StanyMagazynoweForAllView
                    {
                        IdStanuMagazynowego = stanMagazynowy.IdStanuMagazynowego,
                        NazwaProduktu = stanMagazynowy.Produkty.Nazwa,
                        Kategoria = stanMagazynowy.Produkty.Kategorie.Nazwa,
                        IdMagazynu = stanMagazynowy.Magazyny.IdMagazynu,
                        LokalizacjaMagazynu = stanMagazynowy.Magazyny.Lokalizacja,
                        Ilosc = stanMagazynowy.Ilosc
                    }
                );
            }
        }

        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<StanyMagazynoweForAllView>
            (
                from stanMagazynowy in hurtowniaEntities.StanyMagazynowe
                select new StanyMagazynoweForAllView
                {
                    IdStanuMagazynowego = stanMagazynowy.IdStanuMagazynowego,
                    NazwaProduktu = stanMagazynowy.Produkty.Nazwa,
                    Kategoria = stanMagazynowy.Produkty.Kategorie.Nazwa,
                    IdMagazynu = stanMagazynowy.Magazyny.IdMagazynu,
                    LokalizacjaMagazynu = stanMagazynowy.Magazyny.Lokalizacja,
                    Ilosc = stanMagazynowy.Ilosc
                }
            );
        }
        #endregion
    }
}
