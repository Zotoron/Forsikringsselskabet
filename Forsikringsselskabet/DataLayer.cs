using IsButik;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsikringsselskabet
{
    public class DataLayer
    {
        SqlAccess sqlAccess = new SqlAccess();
        ConvertTableToObject ConvertTableToObject;

        public DataLayer()
        {
            ConvertTableToObject = new ConvertTableToObject(sqlAccess);
        }
        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                DataTable table = sqlAccess.ExecuteSql("select * from Kunde");
                return ConvertTableToObject.GetKundeListe(table);
            }
        }

  
    }
}
