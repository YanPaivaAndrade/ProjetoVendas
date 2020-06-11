using System;

namespace ProjetoVendas.Services.Exceções
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base (mensagem)
        {
            
        }
    }
}
