using MVVMFirma.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klienci>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NowyKlientViewModel()
        : base("Nowy Klient")
        {
            item = new Klienci();
        }
        #endregion

        #region Properties
        public string Nazwa
        {
            get { return item.Nazwa; }
            set
            {
                var hasNazwaFirstLetterUpperCase = !string.IsNullOrEmpty(value) && char.IsUpper(value[0]);
                if(!hasNazwaFirstLetterUpperCase)
                {
                    AddError(nameof(Nazwa), "Nazwa musi zaczynać się od wielkiej litery");
                }
                else
                {
                    _validationMessages.Remove(nameof(Nazwa));
                }

                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        public string NIP
        {
            get { return item.NIP; }
            set
            {
                var HasNIPOnlyNumbers = !string.IsNullOrEmpty(value) && value.All(char.IsDigit);
                if (!HasNIPOnlyNumbers)
                {
                    AddError(nameof(NIP), "NIP musi zawierać tylko cyfry");
                }
                else
                {
                    _validationMessages.Remove(nameof(NIP));
                }
                item.NIP = value;
                OnPropertyChanged(() => NIP);
            }
        }

        public string Adres
        {
            get { return item.Adres; }
            set
            {
                var iterator=0;
                foreach (var space in value)
                { 
                    if(space == ' ')
                    {
                        iterator++;
                    }
                }
                var CorrectFormat = !string.IsNullOrEmpty(value) && value.Contains("ul.") && value.Any(char.IsDigit) && iterator>2;
                if (!CorrectFormat)
                {
                    AddError(nameof(Adres), "Podaj adres w formacie: Miasto, ul. Ulica Numer");
                }
                else
                {
                    _validationMessages.Remove(nameof(Adres));
                }
                item.Adres = value;
                OnPropertyChanged(() => Adres);
            }
        }

        public string Telefon
        {
            
            get { return item.Telefon; }
            set
            {
                var HasTelefonOnlyNumbers = !string.IsNullOrEmpty(value) && value.All(char.IsDigit);
                if (!HasTelefonOnlyNumbers)
                {
                    AddError(nameof(Telefon), "Telefon musi zawierać tylko cyfry");
                }
                else
                {
                    _validationMessages.Remove(nameof(Telefon));
                }
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }

        public string Email
        {
            get { return item.Email; }
            set
            {
                var HasEmailAtSign = !string.IsNullOrEmpty(value) && value.Contains("@");
                if (!HasEmailAtSign)
                {
                    AddError(nameof(Email), "Email musi zawierać znak @");
                }
                else
                {
                    _validationMessages.Remove(nameof(Email));
                }

                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        

        #endregion

        #region Helpers
        public override void Save()
        {
                hurtowniaEntities.Klienci.Add(item); //dodaje towar do lokalnej kolekcji 
                hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

        #region validators metoda2
        private readonly Dictionary<string, List<string>> _validationMessages = new Dictionary<string, List<string>>();

        public bool HasErrors => _validationMessages.Any();

        public override bool IsValid()
        {
            return !HasErrors;
        }

        public event EventHandler<DataErrorsChangedEventArgs>  ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_validationMessages.ContainsKey(propertyName))
            {
                return _validationMessages[propertyName];
            }
            return null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string validationMessage)
        {
            if (!_validationMessages.ContainsKey(propertyName))
            {
                _validationMessages[propertyName] = new List<string>();
            }
            if (!_validationMessages[propertyName].Contains(validationMessage))
            {
                _validationMessages[propertyName].Add(validationMessage);
                OnErrorsChanged(propertyName);
            }
        }

        #endregion

    }
}
