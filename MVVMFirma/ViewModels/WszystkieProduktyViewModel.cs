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
    public class WszystkieProduktyViewModel : WszystkieViewModel<ProduktForAllView>
    {

        public WszystkieProduktyViewModel()
            : base("Produkty")
        {
        }

        #region sort and filter

        public string FindTextBox { get; set; }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa produktu", "Kategoria", "Dostawca", "Cena zakupu", "Cena sprzedazy", "Ilosc" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa produktu")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.NazwaProduktu));
            }
            if (SortField == "Kategoria")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.NazwaKategorii));
            }
            if (SortField == "Dostawca")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.NazwaDostawcy));
            }
            if (SortField == "Cena zakupu")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.CenaZakupu));
            }
            if (SortField == "Cena sprzedazy")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.CenaSprzedazy));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<ProduktForAllView>
                (List.OrderBy(item => item.Ilosc));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa produktu", "Kategoria", "Dostawca" };
        }

        public override void Find()
        {
            if (FindTextBox != null)
            {
                if (FindField == "Nazwa produktu")
                {
                    List = new ObservableCollection<ProduktForAllView>
                    (
                        from produkt in hurtowniaEntities.Produkty
                        where produkt.Nazwa.Contains(FindTextBox)
                        select new ProduktForAllView
                        {
                            IdProduktu = produkt.IdProduktu,
                            NazwaProduktu = produkt.Nazwa,
                            NazwaKategorii = produkt.Kategorie.Nazwa,
                            NazwaDostawcy = produkt.DostawcyProduktow.Nazwa,
                            CenaZakupu = produkt.CenaZakupu,
                            CenaSprzedazy = produkt.CenaSprzedazy,
                            Ilosc = produkt.Ilosc
                        }
                    );
                }
                if (FindField == "Kategoria")
                {
                    List = new ObservableCollection<ProduktForAllView>
                    (
                        from produkt in hurtowniaEntities.Produkty
                        where produkt.Kategorie.Nazwa.Contains(FindTextBox)
                        select new ProduktForAllView
                        {
                            IdProduktu = produkt.IdProduktu,
                            NazwaProduktu = produkt.Nazwa,
                            NazwaKategorii = produkt.Kategorie.Nazwa,
                            NazwaDostawcy = produkt.DostawcyProduktow.Nazwa,
                            CenaZakupu = produkt.CenaZakupu,
                            CenaSprzedazy = produkt.CenaSprzedazy,
                            Ilosc = produkt.Ilosc
                        }
                    );
                }
                if (FindField == "Dostawca")
                {
                    List = new ObservableCollection<ProduktForAllView>
                    (
                        from produkt in hurtowniaEntities.Produkty
                        where produkt.DostawcyProduktow.Nazwa.Contains(FindTextBox)
                        select new ProduktForAllView
                        {
                            IdProduktu = produkt.IdProduktu,
                            NazwaProduktu = produkt.Nazwa,
                            NazwaKategorii = produkt.Kategorie.Nazwa,
                            NazwaDostawcy = produkt.DostawcyProduktow.Nazwa,
                            CenaZakupu = produkt.CenaZakupu,
                            CenaSprzedazy = produkt.CenaSprzedazy,
                            Ilosc = produkt.Ilosc
                        }
                    );
                }
            }
        }

        #endregion

        public override void Load()
        {
            List = new ObservableCollection<ProduktForAllView>
            (
                from produkt in hurtowniaEntities.Produkty
                select new ProduktForAllView
                {
                    IdProduktu = produkt.IdProduktu,
                    NazwaProduktu = produkt.Nazwa,
                    NazwaKategorii = produkt.Kategorie.Nazwa,
                    NazwaDostawcy = produkt.DostawcyProduktow.Nazwa,
                    CenaZakupu = produkt.CenaZakupu,
                    CenaSprzedazy = produkt.CenaSprzedazy,
                    Ilosc = produkt.Ilosc
                }
            );
        }
    }
}
