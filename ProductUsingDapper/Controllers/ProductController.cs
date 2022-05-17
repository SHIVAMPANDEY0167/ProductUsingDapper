using Microsoft.AspNetCore.Mvc;
using ProductUsingDapper.Models;
using ProductUsingDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo _productRepo;
        public ProductController() 
        {
            _productRepo = new ProductRepo();
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productRepo.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _productRepo.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            if(ModelState.IsValid)
            {
                _productRepo.Add(product);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            if (ModelState.IsValid)
            {
                _productRepo.Update(product);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepo.Delete(id);
        }
    }
}
