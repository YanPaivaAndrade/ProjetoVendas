using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Vendedor v)
        {
            this.Vendedores.Add(v);
        }
        public void RemoverVendedor(Vendedor v)
        {
            this.Vendedores.Remove(v);
        }
        public double TotalDeVendas(DateTime inicio, DateTime fim)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalDeVendas(inicio, fim));
        }

    }
}
