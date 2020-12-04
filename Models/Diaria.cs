using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Diaria
    {
        public int DiariaID { get; set; }
        public virtual List<Carro>Carros { get; set; }
        public virtual List<Cobrador> Cobradores { get; set; }
        public string Estado { get; set; }
        public DateTime abertura { get; set; }
        public DateTime fecho { get; set; }
    }
}
