using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModel;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersServices _sellersServices;
        private readonly DepartamentServices _departamentServices;

        public SellersController(SellersServices sellersServices, DepartamentServices departamentServices)
        {
            _departamentServices = departamentServices;
            _sellersServices = sellersServices;
        }
        public IActionResult Index()
        {
            var listaDeVendedores = _sellersServices.ListaDeSeller();
            return View(listaDeVendedores);
        }
        public IActionResult Create()
        {
            var departamentos = _departamentServices.FindAll();
            var selerView = new SellerForViewModel { Departaments = departamentos };
            return View(selerView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var seller = _sellersServices.FindById(id.Value);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            return View(seller);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var seller = _sellersServices.FindById(id.Value);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            return View(seller);
        }
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided" });
            }
            var seller = _sellersServices.FindById(id.Value);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
            }
            List<Departament> departaments = _departamentServices.FindAll();
            SellerForViewModel ViewModel = new SellerForViewModel { Departaments = departaments, Seller = seller };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id misMatch" });
            }
            try
            {
                _sellersServices.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        
        }
        public IActionResult Error( string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
