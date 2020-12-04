using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class RotaDestino
    {
        public int RotaDestinoID { get; set; }
        public int RotaID { get; set; }
        public virtual Rota Rota { get; set; }
        public string Destino { get; set; }
    }
}
