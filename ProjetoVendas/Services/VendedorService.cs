using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Services
{
    public class VendedorService
    {
        private readonly ProjetoVendasContext _context;
        public VendedorService(ProjetoVendasContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll() 
        {
            return _context.Vendedore.ToList();
        }
        public Vendedor FindById(int id) 
        {
            return _context.Vendedore.Include(vendedor=> vendedor.Departamento).FirstOrDefault(vendedor => vendedor.Id == id);
        }
        public void Insert (Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var vendedor = _context.Vendedore.Find(id);
            _context.Vendedore.Remove(vendedor);
            _context.SaveChanges();
        }

    }
}
