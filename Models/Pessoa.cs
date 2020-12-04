using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Motorista>Motoristas { get; set; }
        public virtual List<Passageiro>Passageiros { get; set; }
        public virtual List<Cobrador>Cobradores { get; set; }
    }
}
