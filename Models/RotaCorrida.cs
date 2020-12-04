using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class RotaCorrida
    {
        public int RotaCorridaID { get; set; }
        public int RotaID { get; set; }
        public virtual Rota Rota { get; set; }
        public int PagamentoID { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public virtual List<Diaria>Diaria { get; set; }
        public DateTime TimeInicio { get; set; }
        public DateTime TimeFim { get; set; }
        public double Valor { get; set; }
        public string Estado { get; set; }
    }
}
