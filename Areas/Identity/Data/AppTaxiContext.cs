using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTaxi.Areas.Identity.Data;
using AppTaxi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppTaxi.Data
{
    public class AppTaxiContext : IdentityDbContext<AppTaxiUser>
    {
        public AppTaxiContext(DbContextOptions<AppTaxiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cobrador> Cobradores { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<CarteiraPassageiro> CarteiraPassageiros { get; set; }
        public DbSet<RotaDestino> RotaDestinos { get; set; }
        public DbSet<Diaria> Diarias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<RotaCorrida> RotaCorridas { get; set; }
        public DbSet<RotaOrigem> RotaOrigens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
