using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SepetApi.Models;

namespace SepetApi.Controllers
{ 
    public class ProductController : ApiController
    {
        SepetDb db = new SepetDb();
        [HttpGet]
        public List<Product> GetProducts()
        {
            List<Product> _products = db.Products.ToList();
            return _products;
        }
        [HttpGet]
        public Product GetProduct(int id)
        {
            var product = db.Products.FirstOrDefault((p) => p.Id == id);
            return product;
        }
        [HttpGet]
        public List<Product> GetCategoryProduct(int categoryId)
        {
            var product = db.Products.Where((p) => p.CategoryId == categoryId).ToList();
            return product;
        }
        //[HttpGet]
        //public Product Get(int id)
        //{
        //    var product = db.Products.FirstOrDefault((p) => p.Id == id);
        //    return product;
        //}
    }
}
