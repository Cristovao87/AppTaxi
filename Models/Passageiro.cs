using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Passageiro
    {
        public int PassageiroID { get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}
