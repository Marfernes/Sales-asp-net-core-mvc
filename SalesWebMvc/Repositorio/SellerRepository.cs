using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Repositorio
{
    public class SellerRepository : BaseRepositorio<Seller>
    {
        public SellerRepository(SalesWebMvcContext dbContextOptions) : base(dbContextOptions)
        {
            Context = dbContextOptions;
        }
    }
}
