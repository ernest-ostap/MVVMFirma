using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DatabaseClass
    {
        private HurtowniaEntities2 db1;
        #region Context
        public HurtowniaEntities2 db { get => db1; set => db1 = value; }
        #endregion

        #region Konstruktor
        public DatabaseClass(HurtowniaEntities2 db)
        { 
            this.db = db;
        }
        #endregion

    }
}
