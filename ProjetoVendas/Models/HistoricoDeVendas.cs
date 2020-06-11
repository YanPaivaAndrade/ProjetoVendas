using ProjetoVendas.Models.Enumerados;
using System;

namespace ProjetoVendas.Models
{
    public class HistoricoDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusDeVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public HistoricoDeVendas()
        {
        }

        public HistoricoDeVendas( DateTime data, double valor, StatusDeVenda status, Vendedor vendedor)
        {
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
        public HistoricoDeVendas(int id, DateTime data, double valor, StatusDeVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
