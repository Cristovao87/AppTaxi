using AppTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTaxi.Dados
{
    public class Inicializar
    {
        public static void Inicio(TaxiContexto contexto)
        {
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            if (contexto.Carros.Any())
            {
                return;
            }
            var motoristas = new Motorista[]
            {
                new Motorista { Nome="José Cristóvão", BI="0000000LD01"},
                new Motorista { Nome="Cristóvão José", BI="0000000LD02"},
                new Motorista{ Nome="Quiombo Sobrinho", BI="000000LD03"}
            };
            foreach (Motorista i in motoristas)
            {
                contexto.Motoristas.Add(i);
            }
            contexto.SaveChanges();
            var carros = new Carro[]
            {
                new Carro{ Matricula="LD-01-02-XZ",MotoristaID=1},
                new Carro { Matricula="LD-02-03-XZ", MotoristaID=2},
                new Carro{Matricula="LD-03-04-XZ", MotoristaID=3}
            };
            foreach (Carro d in carros)
            {
                contexto.Carros.Add(d);
            }
            contexto.SaveChanges();

        }
    }
}
