using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string User { get; set; }
        public string password { get; set; }
        public string tipo { get; set; }
        public virtual List<Pessoa>Pessoas { get; set; }


    }
}
 