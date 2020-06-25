using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Rota
    {
        public int RotaID { get; set; }
        public string Nome_Rota { get; set; }
        public virtual List<RotaCarro> RotaCarros { get; set; }
    }
}
