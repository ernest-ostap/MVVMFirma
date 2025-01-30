using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKlienciViewModel : WszystkieViewModel<Klienci>
    {
        #region Konstruktor
        public WszyscyKlienciViewModel()
        : base("Klienci")
        {
        }
        #endregion

        #region sort and filter

        public string FindTextBox { get; set; }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "NIP", "Adres", "Telefon", "Email" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Klienci>
                (List.OrderBy(item => item.Nazwa));
            }
            else if (SortField == "NIP")
            {
                List = new ObservableCollection<Klienci>
                (List.OrderBy(item => item.NIP));
            }
            else if (SortField == "Adres")
            {
                List = new ObservableCollection<Klienci>
                (List.OrderBy(item => item.Adres));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<Klienci>
                (List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<Klienci>
                (List.OrderBy(item => item.Email));
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "NIP", "Adres", "Telefon", "Email" };
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Klienci>
                (List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
            else if (FindField == "NIP")
            {
                List = new ObservableCollection<Klienci>
                (List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
            }
            else if (FindField == "Adres")
            {
                List = new ObservableCollection<Klienci>
                (List.Where(item => item.Adres != null && item.Adres.StartsWith(FindTextBox)));
            }
            else if (FindField == "Telefon")
            {
                List = new ObservableCollection<Klienci>
                (List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            }
            else if (FindField == "Email")
            {
                List = new ObservableCollection<Klienci>
                (List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Klienci>
            (hurtowniaEntities.Klienci.ToList());
        }
        #endregion
    }
}
