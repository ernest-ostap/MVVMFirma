using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel // pod T są typy danych listy
    {
        #region DB
        protected readonly HurtowniaEntities2 hurtowniaEntities; //reprezentuje baze danych
        #endregion

        #region Commands
        private BaseCommand _LoadCommand;//to jest komenda, która będzie wywolywala funkcje Load pobierającą z bazy danych towary
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }

        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => Add());
                return _AddCommand;
            }
        }

        #endregion

        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if(_List == null)
                {
                    Load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion

        #region Constructor
        public WszystkieViewModel(string displayname)
        {
            hurtowniaEntities = new HurtowniaEntities2();
            base.DisplayName = displayname;
        }
        #endregion

        #region Sort and Filtr
        //do sortowania 
        //wynik wyboru po czym sortowac zostanie zapisany w SortField
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public abstract List<string> GetComboboxSortList();
        private BaseCommand _SortCommand;//to jest komenda, która będzie wywolywala po nacisnieciu na przycisk sortuj w widoku (generic.xaml)
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }

        public abstract void Sort();

        //do filtrowania 
        public string FindField { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public abstract List<string> GetComboboxFindList();
        private BaseCommand _FindCommand;//to jest komenda, która będzie wywolywala po nacisnieciu na przycisk szukaj w widoku (generic.xaml)
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }

        public abstract void Find();
        #endregion

        #region Helpers
        public abstract void Load(); 

        public void Add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion

    }
}
