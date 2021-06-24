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
            var selerView = new SellerForViewModel { Departaments = departamentos};
            return View(selerView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
