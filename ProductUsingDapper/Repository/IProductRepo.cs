using ProductUsingDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUsingDapper.Repository
{
    interface IProductRepo
    {
        public void Add(ProductModel product);
        IEnumerable<ProductModel> GetAll();
        ProductModel GetById(int id);
        void Delete(int id);
        void Update(ProductModel product);
    }
}
