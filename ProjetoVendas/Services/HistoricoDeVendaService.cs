using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Services
{
    public class HistoricoDeVendaService
    {
        private readonly ProjetoVendasContext _context;
        public HistoricoDeVendaService(ProjetoVendasContext context)
        {
            _context = context;
        }
        public async Task<List<HistoricoDeVenda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.HistoricoDeVenda select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(historico => historico.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(historico => historico.Data <= maxDate.Value);
            }
            return await resultado
                .Include(historico => historico.Vendedor)
                .Include(historico => historico.Vendedor.Departamento)
                .OrderByDescending(historico => historico.Data).ToListAsync();
        }
        public async Task<List<IGrouping<Departamento,HistoricoDeVenda>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.HistoricoDeVenda select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(historico => historico.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(historico => historico.Data <= maxDate.Value);
            }
            List<HistoricoDeVenda> lista = await resultado.Include(historico => historico.Vendedor)
                .Include(historico => historico.Vendedor.Departamento)
                .OrderByDescending(historico => historico.Data).ToListAsync();
            return lista.GroupBy(historico => historico.Vendedor.Departamento).ToList();
        }
    }
}
