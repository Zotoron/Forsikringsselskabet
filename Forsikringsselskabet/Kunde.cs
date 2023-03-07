using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsikringsselskabet
{
    public class Kunde
    {
        public string Navn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public string Telefon { get; set; }
        public int Id { get; set; }
    }
}
