using System;

namespace ProjetoVendas.Services.Exceções
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string menssagem) : base (menssagem)
        { 

        }
    }
}
