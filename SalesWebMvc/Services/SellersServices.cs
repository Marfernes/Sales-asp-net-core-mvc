using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellersServices
    {
        private readonly SalesWebMvcContext _context;

        public SellersServices(SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Seller> ListaDeSeller()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(s => s.Departament).FirstOrDefault(s => s.Id == id);
        }
        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
        public void Update(Seller seller)
        {
            if (! _context.Seller.Any( s => s.Id == seller.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
