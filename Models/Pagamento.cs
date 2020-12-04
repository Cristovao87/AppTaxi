using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Pagamento
    {
        public int PagamentoID { get; set; }
        public virtual List<CarteiraPassageiro>CarteiraPassageiros { get; set; }
        public virtual List<RotaCorrida>RotaCorridas { get; set; }
        public double Valor { get; set; }
        public string tipo { get; set; }
        public string Estado { get; set; }
    }
}
