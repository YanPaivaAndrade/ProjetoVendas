﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Models;
using ProjetoVendas.Models.Enumerados;

namespace ProjetoVendas.Data
{
    public class ProjetoVendasContext : DbContext
    {
        public ProjetoVendasContext (DbContextOptions<ProjetoVendasContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<HistoricoDeVendas> HistoricoDeVenda { get; set; }
        public DbSet<Vendedor> Vendedore { get; set; }


    }
}
