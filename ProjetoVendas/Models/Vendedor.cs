using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<HistoricoDeVendas> Vendas { get; set; } = new List<HistoricoDeVendas>();

        public Vendedor()
        {
        }
        public Vendedor(string nome, string email, DateTime dataDeNascimento, double salario, Departamento departamento)
        {
            this.nome = nome;
            this.email = email;
            DataDeNascimento = dataDeNascimento;
            Salario = salario;
            Departamento = departamento;
        }
        public Vendedor(int id, string nome, string email, DateTime dataDeNascimento, double salario, Departamento departamento)
        {
            Id = id;
            this.nome = nome;
            this.email = email;
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
