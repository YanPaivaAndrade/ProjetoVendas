using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Services.Exceções;
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

        public async Task<List<Vendedor>> FindAllAsync() 
        {
            return await _context.Vendedore.ToListAsync();
        }
        public async Task<Vendedor> FindByIdAsync(int id) 
        {
            return await _context.Vendedore.Include(vendedor=> vendedor.Departamento).FirstOrDefaultAsync(vendedor => vendedor.Id == id);
        }
        public async Task InsertAsync (Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var vendedor = await _context.Vendedore.FindAsync(id);
            _context.Vendedore.Remove(vendedor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Vendedor vendedor) 
        {
            bool validadorDeObj = await _context.Vendedore.AnyAsync(obj => obj.Id == vendedor.Id);
            if (!validadorDeObj)
            {
                throw new NotFoundException("Id não encontrado"); 
            }
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
