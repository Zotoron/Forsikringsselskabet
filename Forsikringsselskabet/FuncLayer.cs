using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsikringsselskabet
{
    public class FuncLayer : INotifyPropertyChanged
    {

        DataLayer DataLayer { get; set; } = new DataLayer();

        public ObservableCollection<Kunde> KundeListe
        {
            get { return DataLayer.KundeListe; }
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

            DataLayer.KundeListe.Add(kunde);
            RaisePropertyChanged(nameof(KundeListe));
        }
    }
}
