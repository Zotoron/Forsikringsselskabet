
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
            FuncLayer.TilføjKunde(tbNavn.Text, tbEfternavn.Text, tbAdresse.Text, tbPostnummer.Text, tbTelefon.Text);
            
        }

    }
}