using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Carro
    {
        public int CarroID { get; set; }
        public string Matricula { get; set; }
        public int DiariaID { get; set; }
        public virtual Diaria Diaria { get; set; }
        public virtual List<Pessoa> Pessoas { get; set; }
    }
}
