using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModel;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
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
                return NotFound();
            }
            var seller = _sellersServices.FindById(id.Value);
            if (seller == null)
            {
                return NotFound();
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
                return NotFound();
            }
            var seller = _sellersServices.FindById(id.Value);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

    }
}
