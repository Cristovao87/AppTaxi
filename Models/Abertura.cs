using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Models
{
    public class Abertura
    {
        public int AberturaID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        [Display(Name ="Dia de Abertura")]
        public DateTime Dia { get; set; }
        [DisplayFormat(DataFormatString ="{0:hh:mm}")]
        [Display(Name = "Hora de Abertura")]
        public DateTime Hora { get; set; }
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
    }
}
