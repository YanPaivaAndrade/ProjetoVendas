using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoVendas.Models;
using ProjetoVendas.Models.ViewModels;
using ProjetoVendas.Services;
using ProjetoVendas.Services.Exceções;

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
            var vendedorViewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(vendedorViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var vendedor = _vendedorService.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            return View(vendedor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var vendedor = _vendedorService.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            return View(vendedor);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não fornecido" });
            }
            var vendedor = _vendedorService.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não encontrado" });
            }
            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel {Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { menssagem = "id não corresponde ao vendedor" });
            }
            try
            {
                _vendedorService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { menssagem = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { menssagem = e.Message});
            }
        }
        public IActionResult Error(string menssagem)
        {
            var viewModel = new ErrorViewModel
            {
                Menssagem = menssagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
