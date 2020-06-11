using System;

namespace ProjetoVendas.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Menssagem { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
