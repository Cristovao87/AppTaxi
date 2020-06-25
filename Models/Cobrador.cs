using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Cobrador
    {
        public int CobradorID { get; set; }
        public string Nome { get; set; }
        public string BI { get; set; }
        public virtual List<Carro> Carros { get; set; }
    }
}
