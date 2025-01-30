using GalaSoft.MvvmLight.Helpers;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyPracownikViewModel : JedenViewModel<Pracownicy>, IDataErrorInfo
    {
        private string validationMessage;

        #region Konstruktor
        public NowyPracownikViewModel()
        : base("Nowy Pracownik")
        {
            item = new Pracownicy();
            validationMessage = string.Empty;
        }

        #endregion

        #region Properties
        public string Imie
        {
            get { return item.Imie; }
            set
            { 
                item.Imie = value;
                OnPropertyChanged(()=>Imie);
            }
        }

        public string Nazwisko
        {
            get { return item.Nazwisko; }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public string Stanowisko
        {
            get { return item.Stanowisko; }
            set
            {
                item.Stanowisko = value;
                OnPropertyChanged(() => Stanowisko);
            }
        }

        public decimal? Placa
        {
            get { return item.Placa; }
            set
            {
                item.Placa = value;
                OnPropertyChanged(() => Placa);
            }
        }

        public string RodzajUmowy
        {
            get { return item.RodzajUmowy; }
            set
            {
                item.RodzajUmowy = value;
                OnPropertyChanged(() => RodzajUmowy);
            }
        }


        #endregion

        #region Helpers
        public override void Save()
        {
            
                hurtowniaEntities.Pracownicy.Add(item); //dodaje towar do lokalnej kolekcji 
                hurtowniaEntities.SaveChanges();//zapisuje zmiany do bazy danych
            

        }

        public override bool IsValid()
        {
            return string.IsNullOrEmpty(validationMessage);
        }
        #endregion

        #region validators
        public string Error => string.Empty;
        public string this[string prop]
        {
            get
            {
                if (prop == "Imie")
                {
                    validationMessage = StringValidator.ValidateIsFirstLetterUpper(Imie);
                }

                if (prop == "Nazwisko")
                {
                    validationMessage = StringValidator.ValidateIsFirstLetterUpper(Nazwisko);
                }

                if (prop == "Placa")
                {
                    validationMessage = PositiveNumberValidator.ValidatePositiveNumber(Placa);
                }
                if (prop == "Stanowisko")
                {
                    validationMessage = StringLengthValidator.FieldLengthValidator(Stanowisko, 3);
                }
                if (prop == "RodzajUmowy")
                {
                    validationMessage = StringLengthValidator.FieldLengthValidator(RodzajUmowy, 1);
                }


                return validationMessage;

            }
        }
        #endregion



    }
}
