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
