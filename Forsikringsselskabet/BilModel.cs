using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forsikringsselskabet
{
    public class BilModel
    {
        public string Mærke { get; set; }
        public string Model { get; set; }
        public string Startår { get; set; }
        public string Slutår { get; set; }
        public string Standardpris { get; set; }
        public string Forsikringssum { get; set; }
        public int Id { get; set; }
    }
}
