﻿using Microsoft.AspNetCore.Mvc;
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

        public SellersController(SellersServices sellersServices )
        {
            _sellersServices = sellersServices;
        }
        public IActionResult Index()
        {
            var listaDeVendedores = _sellersServices.ListaDeSeller();
            return View(listaDeVendedores);
        }
    }
}
