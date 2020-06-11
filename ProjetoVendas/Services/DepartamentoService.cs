﻿using ProjetoVendas.Data;
using ProjetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Services
{
    public class DepartamentoService
    {
        private readonly ProjetoVendasContext _context;
        public DepartamentoService(ProjetoVendasContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(departamento => departamento.Nome).ToList();
        }
       
    }
}
