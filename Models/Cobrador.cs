﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Cobrador
    {
        public int CobradorID { get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int DiariaID { get; set; }
        public virtual Diaria Diaria { get; set; }
        public string NumeroAssociado { get; set; }
    }
}
