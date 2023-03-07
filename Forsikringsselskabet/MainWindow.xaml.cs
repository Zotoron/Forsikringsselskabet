
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Forsikringsselskabet
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public FuncLayer FuncLayer { get; set; } = new FuncLayer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void btnOpret_Click(object sender, RoutedEventArgs e)
        {
            if (KundeListe.SelectedIndex == -1)
            {
                FuncLayer.TilføjKunde(tbNavn.Text, tbEfternavn.Text, tbAdresse.Text, tbPostnummer.Text, tbTelefon.Text);
            }
            else
            {
                int Id = (KundeListe.SelectedItem as Kunde).Id;
                FuncLayer.RedigerKunde(Id, tbNavn.Text, tbEfternavn.Text, tbAdresse.Text, tbPostnummer.Text, tbTelefon.Text);
            }
        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                FuncLayer.FjernKunde(KundeListe.SelectedItem as Kunde);
            }
        }

        private void btnRediger_Click(object sender, RoutedEventArgs e)
        {
            tbNavn.Text = (KundeListe.SelectedItem as Kunde).Navn;
            tbEfternavn.Text = (KundeListe.SelectedItem as Kunde).Efternavn;
            tbAdresse.Text = (KundeListe.SelectedItem as Kunde).Adresse;
            tbPostnummer.Text = (KundeListe.SelectedItem as Kunde).Postnummer;
            tbTelefon.Text = (KundeListe.SelectedItem as Kunde).Telefon;

        }

        private void btnOpretbil_Click(object sender, RoutedEventArgs e)
        {
            if (BilListe.SelectedIndex == -1)
            {
                FuncLayer.TilføjBilModel(tbMærke.Text, tbModel.Text, tbStartår.Text, tbSlutår.Text, tbStandardpris.Text, tbForsikringssum.Text);
            }
            else
            {
                int Id = (BilListe.SelectedItem as BilModel).Id;
                FuncLayer.RedigerBilModel(Id, tbMærke.Text, tbModel.Text, tbStartår.Text, tbSlutår.Text, tbStandardpris.Text, tbForsikringssum.Text);
            }
        }

        private void btnRedigerbil_Click(object sender, RoutedEventArgs e)
        {
            tbMærke.Text = (BilListe.SelectedItem as BilModel).Mærke;
            tbModel.Text = (BilListe.SelectedItem as BilModel).Model;
            tbStartår.Text = (BilListe.SelectedItem as BilModel).Startår;
            tbSlutår.Text = (BilListe.SelectedItem as BilModel).Slutår;
            tbStandardpris.Text = (BilListe.SelectedItem as BilModel).Standardpris;
            tbForsikringssum.Text = (BilListe.SelectedItem as BilModel).Forsikringssum;

        }

        private void btnSletbil_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                FuncLayer.FjernBilModel(BilListe.SelectedItem as BilModel);
            }
        }
    }
}