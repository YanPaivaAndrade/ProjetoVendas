using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoVendas.Models;
using ProjetoVendas.Models.ViewModels;
using ProjetoVendas.Services;

namespace ProjetoVendas.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;
        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var vendedorViewModel = new VendedorFormViewModel {Departamentos=departamentos };
            return View(vendedorViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vendedor = _vendedorService.FindById(id.Value);
            if (vendedor == null) 
            {
                return NotFound();
            }
            return View(vendedor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
