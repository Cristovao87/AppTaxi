using AppTaxi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Dados
{
    public class TaxiContexto: DbContext
    {
        public TaxiContexto(DbContextOptions<TaxiContexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //RotaCarro
            modelBuilder.Entity<RotaCarro>()
                .HasKey(rc => new { rc.RotaID, rc.CarroID });

            //Carro
            modelBuilder.Entity<RotaCarro>()
                .HasOne(c => c.Carro)
                .WithMany(rc => rc.RotaCarros)
                .HasForeignKey(c => c.CarroID);

            //Rota
            modelBuilder.Entity<RotaCarro>()
                .HasOne(r => r.Rota)
                .WithMany(rc => rc.RotaCarros)
                .HasForeignKey(r => r.RotaID);
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cobrador> Cobradores { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<AppTaxi.Models.RotaCarro> RotaCarro { get; set; }
        public DbSet<Abertura> Aberturas { get; set; }
    }
}
