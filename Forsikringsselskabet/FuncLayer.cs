using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Forsikringsselskabet
{
    public class FuncLayer : INotifyPropertyChanged
    {

        DataLayer DataLayer { get; set; } = new DataLayer();

        public ObservableCollection<Kunde> KundeListe
        {
            get { return DataLayer.KundeListe; }
        }
        public ObservableCollection<BilModel> BilListe
        {
            get { return DataLayer.BilListe; }
        }
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void TilføjKunde(string navn, string efternavn, string adresse, string postnummer, string telefon)
        {
            Kunde kunde = new Kunde();
            kunde.Navn = navn;
            kunde.Efternavn = efternavn;
            kunde.Adresse = adresse;
            kunde.Postnummer = postnummer;
            kunde.Telefon = telefon;


            DataLayer.TilføjKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
        }

        public void FjernKunde(Kunde kunde)
        {
            DataLayer.FjernKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
        }

        public void RedigerKunde(int Id, string navn, string efternavn, string adresse, string postnummer, string telefon)
        {

            Kunde kunde = new Kunde();
            kunde.Id = Id;
            kunde.Navn = navn;
            kunde.Efternavn = efternavn;
            kunde.Adresse = adresse;
            kunde.Postnummer = postnummer;
            kunde.Telefon = telefon;

            DataLayer.RedigerKunde(kunde);
            RaisePropertyChanged(nameof(KundeListe));
        }

        public void TilføjBilModel(string mærke, string model, string startår, string slutår, string standardpris, string forsikringssum)
        {
            BilModel bilmodel = new BilModel();
            bilmodel.Mærke = mærke;
            bilmodel.Model = model;
            bilmodel.Startår = startår;
            bilmodel.Slutår = slutår;
            bilmodel.Standardpris = standardpris;
            bilmodel.Forsikringssum = forsikringssum;


            DataLayer.TilføjBilModel(bilmodel);
            RaisePropertyChanged(nameof(BilListe));
        }

        public void RedigerBilModel(int Id, string mærke, string model, string startår, string slutår, string standardpris, string forsikringssum)
        {

            BilModel bilmodel = new BilModel();
            bilmodel.Id = Id;
            bilmodel.Mærke = mærke;
            bilmodel.Model = model;
            bilmodel.Startår = startår;
            bilmodel.Slutår = slutår;
            bilmodel.Standardpris = standardpris;
            bilmodel.Forsikringssum = forsikringssum;

            DataLayer.RedigerBilModel(bilmodel);
            RaisePropertyChanged(nameof(BilListe));
        }

        public void FjernBilModel(BilModel bilmodel)
        {
            DataLayer.FjernBilModel(bilmodel);
            RaisePropertyChanged(nameof(BilListe));
        }
    }
}
