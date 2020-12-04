using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class RotaOrigem
    {
        public int RotaOrigemID { get; set; }
        public int RotaID { get; set; }
        public virtual Rota Rota { get; set; }
        public string Origem { get; set; }
    }
}
