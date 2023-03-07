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
        public ObservableCollection<BilModel> BilListe
        {
            get
            {
                DataTable table = sqlAccess.ExecuteSql("select * from BilModel");
                return ConvertTableToObject.GetBilListe(table);
            }
        }
        public void TilføjKunde(Kunde kunde)
        {

            sqlAccess.ExecuteSql($"insert into Kunde (Navn, Efternavn, Adresse, Postnummer, Telefon) values ('{kunde.Navn}','{kunde.Efternavn}','{kunde.Adresse}','{kunde.Postnummer}','{kunde.Telefon}')");
        }

        public void TilføjBilModel(BilModel bilmodel)
        {

            sqlAccess.ExecuteSql($"insert into BilModel (Mærke, Model, Startår, Slutår, Standardpris, Forsikringssum) values ('{bilmodel.Mærke}','{bilmodel.Model}','{bilmodel.Startår}','{bilmodel.Slutår}','{bilmodel.Standardpris}','{bilmodel.Forsikringssum}')");
        }

        public void FjernKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"delete from Kunde where Id = {kunde.Id}");
        }

        public void RedigerKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"update Kunde set Navn = '{kunde.Navn}', Efternavn = '{kunde.Efternavn}', Adresse = '{kunde.Adresse}', Postnummer = '{kunde.Postnummer}', Telefon = '{kunde.Telefon}' where Id = {kunde.Id}");

        }

        public void RedigerBilModel(BilModel bilmodel)
        {
            sqlAccess.ExecuteSql($"update BilModel set Mærke = '{bilmodel.Mærke}', Model = '{bilmodel.Model}', Startår = '{bilmodel.Startår}', Slutår = '{bilmodel.Slutår}', Standardpris = '{bilmodel.Standardpris}', Forsikringssum = '{bilmodel.Forsikringssum}' where Id = {bilmodel.Id}");

        }

        public void FjernBilModel(BilModel bilmodel)
        {
            sqlAccess.ExecuteSql($"delete from BilModel where Id = {bilmodel.Id}");
        }

    }
}
