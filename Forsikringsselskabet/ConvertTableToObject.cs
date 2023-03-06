using Forsikringsselskabet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsButik
{
    internal class ConvertTableToObject
    {
        SqlAccess sqlAccess;
        public ConvertTableToObject(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }

        public ObservableCollection<Kunde> GetKundeListe(DataTable table)
        {
            ObservableCollection<Kunde> liste = new ObservableCollection<Kunde>();
            foreach (DataRow row in table.Rows)
            {
                Kunde kunde = GetKunde(row);
                liste.Add(kunde);
            }
            return liste;
        }

        //public ObservableCollection<Bestilling> GetBestillingsliste(DataTable table)
        //{
        //    ObservableCollection<Bestilling> liste = new ObservableCollection<Bestilling>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        Bestilling Bestilling = GetBestilling(row);
        //        liste.Add(Bestilling);
        //    }
        //    return liste;
        //}

        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde();
            kunde.Navn = (string)row["Navn"];
            kunde.Efternavn = (string)row["Efternavn"];
            kunde.Adresse = (string)row["Adresse"];
            kunde.Postnummer = (string)row["Postnummer"];
            kunde.Telefon = (string)row["Telefon"];
            return kunde;
        }

        //private Bestilling GetBestilling(DataRow bestillingsRow)
        //{
        //    // select * from Vare where Id = (int)row["Id"]
        //    DataTable table = sqlAccess.ExecuteSql($"select * from Vare where Id = {(int)bestillingsRow["VareId"]}");
        //    DataRow vareRow = table.Rows[0];
        //    Vare vare = GetVare(vareRow);

        //    Bestilling bestilling = new Bestilling(vare, (int)bestillingsRow["Antal"]);
        //    bestilling.Id = (int)bestillingsRow["Id"];
        //    return bestilling;
        //}
    }
}
