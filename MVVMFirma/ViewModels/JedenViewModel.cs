using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected HurtowniaEntities2 hurtowniaEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        //to jest komenda, która zostanie podpieta pod przycisk zapisz i zamknij i ona wyowla funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }

        #endregion
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            hurtowniaEntities = new HurtowniaEntities2();
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            if (IsValid())
            {
                Save();
                base.OnRequestClose();
            }
            else
            {
                ShowMessageBox("Popraw błędy w formularzu ;)");
            }
            
        }
        #endregion


        public virtual bool IsValid()
        {
            return true;
        }
    }
}
