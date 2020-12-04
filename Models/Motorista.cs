using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Motorista
    {
        public int MotoristaID { get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public string NumeroCarta { get; set; }
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
       
    }
}
