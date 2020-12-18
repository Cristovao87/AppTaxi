using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AppTaxi.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppTaxiUser class
    public class AppTaxiUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string PrimeiroNome { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string UltimoNome { get; set; }
    }
}
