﻿// <auto-generated />
using AppTaxi.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppTaxi.Migrations
{
    [DbContext(typeof(TaxiContexto))]
    partial class TaxiContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppTaxi.Models.Carro", b =>
                {
                    b.Property<int>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CobradorID");

                    b.Property<string>("Matricula");

                    b.Property<int>("MotoristaID");

                    b.HasKey("CarroID");

                    b.HasIndex("CobradorID");

                    b.HasIndex("MotoristaID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("AppTaxi.Models.Cobrador", b =>
                {
                    b.Property<int>("CobradorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BI");

                    b.Property<string>("Nome");

                    b.HasKey("CobradorID");

                    b.ToTable("Cobradores");
                });

            modelBuilder.Entity("AppTaxi.Models.Motorista", b =>
                {
                    b.Property<int>("MotoristaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BI");

                    b.Property<string>("Nome");

                    b.HasKey("MotoristaID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("AppTaxi.Models.Rota", b =>
                {
                    b.Property<int>("RotaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Rota");

                    b.HasKey("RotaID");

                    b.ToTable("Rotas");
                });

            modelBuilder.Entity("AppTaxi.Models.RotaCarro", b =>
                {
                    b.Property<int>("RotaID");

                    b.Property<int>("CarroID");

                    b.HasKey("RotaID", "CarroID");

                    b.HasIndex("CarroID");

                    b.ToTable("RotaCarro");
                });

            modelBuilder.Entity("AppTaxi.Models.Carro", b =>
                {
                    b.HasOne("AppTaxi.Models.Cobrador", "Cobrador")
                        .WithMany("Carros")
                        .HasForeignKey("CobradorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppTaxi.Models.Motorista", "Motorista")
                        .WithMany("Carros")
                        .HasForeignKey("MotoristaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppTaxi.Models.RotaCarro", b =>
                {
                    b.HasOne("AppTaxi.Models.Carro", "Carro")
                        .WithMany("RotaCarros")
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppTaxi.Models.Rota", "Rota")
                        .WithMany("RotaCarros")
                        .HasForeignKey("RotaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
