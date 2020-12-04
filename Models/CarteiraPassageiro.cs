using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class CarteiraPassageiro
    {
        public int CarteiraPassageiroID { get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public double Saldo { get; set; }
        public int PagamentoID { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}
