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
        public int MotoristaID { get; set; }
        public virtual Motorista Motorista { get; set; }
        public int CobradorID { get; set; }
        public virtual Cobrador Cobrador { get; set; }
        public virtual List<RotaCarro> RotaCarros { get; set; }
    }
}
