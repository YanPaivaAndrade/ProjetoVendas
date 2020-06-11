using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<HistoricoDeVendas> Vendas { get; set; } = new List<HistoricoDeVendas>();

        public Vendedor()
        {
        }
        public Vendedor(string nome, string email, DateTime dataDeNascimento, double salario, Departamento departamento)
        {
            this.Nome = nome;
            this.Email = email;
            DataDeNascimento = dataDeNascimento;
            Salario = salario;
            Departamento = departamento;
        }
        public Vendedor(int id, string nome, string email, DateTime dataDeNascimento, double salario, Departamento departamento)
        {
            Id = id;
            this.Nome = nome;
            this.Email = email;
            DataDeNascimento = dataDeNascimento;
            Salario = salario;
            Departamento = departamento;
        }
        public void AddVendas(HistoricoDeVendas hv) 
        {
            this.Vendas.Add(hv);
        }
        public void RemoverVendas(HistoricoDeVendas hv)
        {
            this.Vendas.Remove(hv);
        }
        public double TotalDeVendas(DateTime inicio, DateTime final) 
        {
            return Vendas.Where(hv => hv.Data >= inicio && hv.Data <= final).Sum(hv=> hv.Valor);       
        }
    }
}
