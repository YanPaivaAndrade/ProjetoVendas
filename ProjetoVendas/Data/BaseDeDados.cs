using ProjetoVendas.Models;
using ProjetoVendas.Models.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Data
{
    public class BaseDeDados
    {
        private ProjetoVendasContext _context;

        public BaseDeDados(ProjetoVendasContext context)
        {
            _context = context;
        }

        public void Gerar() 
        {
            if (_context.Departamento.Any() || _context.Vendedore.Any() || _context.HistoricoDeVenda.Any())
            {
                return;
            }
            Departamento d1 = new Departamento( "Celulares");
            Departamento d2 = new Departamento( "Cozinha");
            Departamento d3 = new Departamento( "Sala");
            Departamento d4 = new Departamento( "Jogos");
            
            Vendedor v1 = new Vendedor("João", "joão@gmail.com",new DateTime(1981, 6, 4), 2000.00, d1);
            Vendedor v2 = new Vendedor("Lucas", "Lucas@gmail.com", new DateTime(1990, 4, 4), 3000.00, d2);
            Vendedor v3 = new Vendedor("Frederico", "Frederico@gmail.com", new DateTime(1991, 3, 4), 4000.00, d3);
            Vendedor v4 = new Vendedor("Lorraine", "Lorraine@gmail.com", new DateTime(1995, 6, 5), 2000.00, d1);
            Vendedor v5 = new Vendedor("Aline", "Aline@gmail.com", new DateTime(1998, 6, 6), 5000.00, d4);

            HistoricoDeVenda hv1 = new HistoricoDeVenda(new DateTime(2020, 3, 3), 1500.00, StatusDeVenda.Vendido, v1);
            HistoricoDeVenda hv2 = new HistoricoDeVenda(new DateTime(2020, 5, 10), 1500.00, StatusDeVenda.Vendido, v4);
            HistoricoDeVenda hv3 = new HistoricoDeVenda(new DateTime(2020, 4, 11), 2500.00, StatusDeVenda.Vendido, v3);
            HistoricoDeVenda hv4 = new HistoricoDeVenda(new DateTime(2020, 2, 12), 500.00, StatusDeVenda.Vendido, v2);
            HistoricoDeVenda hv5 = new HistoricoDeVenda(new DateTime(2020, 1, 13), 10.00, StatusDeVenda.Vendido, v5);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedore.AddRange(v1, v2, v3, v4, v5);
            _context.HistoricoDeVenda.AddRange(hv1, hv2, hv3, hv4, hv5);

            _context.SaveChanges();

        }
    }
}
