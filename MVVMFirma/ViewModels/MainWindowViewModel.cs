using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media;
using System.Xml.Linq;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        private string message;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, Open);
            return new List<CommandViewModel>
            {
                //nowy viewmodel bez kluczy obcych / zakomentowane z powodu wywoływania przez przycisk Dodaj
                /*
                new CommandViewModel(
                    "Nowy pracownik",
                    new BaseCommand(() => this.CreateView(new NowyPracownikViewModel()))),
                new CommandViewModel(
                    "Nowy klient",
                    new BaseCommand(() => this.CreateView(new NowyKlientViewModel()))),
                new CommandViewModel(
                    "Nowy magazyn",
                    new BaseCommand(() => this.CreateView(new NowyMagazynViewModel()))),
                new CommandViewModel(
                    "Nowy dostawca",
                    new BaseCommand(() => this.CreateView(new NowyDostawcaViewModel()))),
                new CommandViewModel(
                    "Nowa kategoria",
                    new BaseCommand(() => this.CreateView(new NowaKategoriaViewModel()))),
                */
                //wszystkie viewmodel z kluczami obcymi
                new CommandViewModel(
                    "Dostawy",
                    new BaseCommand(() => this.ShowAllView <WszystkieDostawyViewModel>("Dostawy"))),
                new CommandViewModel(
                    "Zamowienia",
                    new BaseCommand(() => this.ShowAllView <WszystkieZamowieniaViewModel>("Zamowienia"))),
                new CommandViewModel(
                    "Produkty",
                    new BaseCommand(() => this.ShowAllView <WszystkieProduktyViewModel>("Produkty"))),
                new CommandViewModel(
                    "Pozycje zamowienia",
                    new BaseCommand(() => this.ShowAllView <WszystkiePozycjeZamowieniaViewModel>("Pozycje zamowienia"))),
                new CommandViewModel(
                    "Stany magazynowe",
                    new BaseCommand(() => this.ShowAllView <WszystkieStanyMagazynoweViewModel>("Stany magazynowe"))),
                new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllView <WszystkieFakturyViewModel>("Faktury"))),
                new CommandViewModel(
                    "Platnosci",
                    new BaseCommand(() => this.ShowAllView <WszystkiePlatnosciViewModel>("Platnosci"))),
                new CommandViewModel(
                    "Zwroty",
                    new BaseCommand(() => this.ShowAllView <WszystkieZwrotyViewModel>("Zwroty"))),
                new CommandViewModel(
                    "Pozycje faktury",
                    new BaseCommand(() => this.ShowAllView <WszystkiePozycjeFakturyViewModel>("Pozycje faktury"))),
                new CommandViewModel(
                    "Wydania",
                    new BaseCommand(() => this.ShowAllView <WszystkieWydaniaViewModel>("Wydania"))),
                //wszystkie viewmodel bez kluczy obcych
                new CommandViewModel(
                    "Pracownicy",
                    new BaseCommand(() => this.ShowAllView <WszyscyPracownicyViewModel>("Pracownicy"))),
                new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.ShowAllView <WszyscyKlienciViewModel>("Klienci"))),
                new CommandViewModel(
                    "Magazyny",
                     new BaseCommand(() => this.ShowAllView <WszystkieMagazynyViewModel>("Magazyny"))),
                new CommandViewModel(
                    "Dostawcy",
                     new BaseCommand(() => this.ShowAllView<WszyscyDostawcyViewModel>("Dostawcy"))),
                new CommandViewModel(
                    "Kategorie",
                     new BaseCommand(() => this.ShowAllView<WszystkieKategorieViewModel>("Kategorie")))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }
        private void ShowAllView<T>(string name)
            where T : WorkspaceViewModel, new()
        {
            T workspace = this.Workspaces.FirstOrDefault(vm => vm is T) as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void Open(string name)//name to jest wyslany komunikat
        {
            if (name == "PracownicyAdd")
            {
                CreateView(new NowyPracownikViewModel());
            }
            if (name == "KlienciAdd")
            {
                CreateView(new NowyKlientViewModel());
            }
            if (name == "MagazynyAdd")
            {
                CreateView(new NowyMagazynViewModel());
            }
            if (name == "DostawcyAdd")
            {
                CreateView(new NowyDostawcaViewModel());
            }
            if (name == "KategorieAdd")
            {
                CreateView(new NowaKategoriaViewModel());
            }

            //dalej dodawanie z kluczami obcymi

            if (name == "WydaniaAdd")
            { 
                CreateView(new NoweWydanieViewModel());
            }

            if (name == "ProduktyAdd")
            {
                CreateView(new NowyProduktViewModel());
            }

            if (name == "DostawyAdd")
            {
                CreateView(new NowaDostawaViewModel());
            }

            if (name == "ZamowieniaAdd")
            {
                CreateView(new NoweZamowienieViewModel());
            }

            if (name == "PlatnosciAdd")
            {
                CreateView(new NowaPlatnoscViewModel());
            }

            if (name == "Pozycje fakturyAdd")
            {
                CreateView(new NowaPozycjaFakturyViewModel());
            }

            if (name == "ZwrotyAdd")
            {
                CreateView(new NowyZwrotViewModel());
            }

            //wszystkie dla okien modalnych
            if (name.StartsWith("DostawcyAll"))
            {
                CreateView(new WszyscyDostawcyViewModel());
                string originalMessage = name;
                string messageToSend = originalMessage.Substring("DostawcyAll".Length);
                Debug.WriteLine(messageToSend); // "Produkt" etc.
                Messenger.Default.Send<string>(messageToSend, "dodostawcy");
            }
            if(name.StartsWith("FakturyAll"))
            {
                CreateView(new WszystkieFakturyViewModel());
                string originalMessage = name;
                string messageToSend = originalMessage.Substring("FakturyAll".Length);
                Debug.WriteLine(messageToSend); // "Platnosci" etc.
                Messenger.Default.Send<string>(messageToSend, "dofaktury");
            }
        }
        #endregion
    }
}
