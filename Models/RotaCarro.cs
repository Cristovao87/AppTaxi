using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class RotaCarro
    {
        public int RotaID { get; set; }
        public virtual Rota Rota { get; set; }
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
    }
}
