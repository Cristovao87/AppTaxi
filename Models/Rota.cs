﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Rota
    {
        public int RotaID { get; set; }
        public double Custo { get; set; }
        public string Estado { get; set; }

    }
}
