using _01_ViewModel.Data;
using _01_ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_ViewModel.Controllers
{
    public class ProductController : Controller
    {


        [HttpGet]
        public ActionResult Index()
        {

            ProductListViewModel model = new ProductListViewModel();
            model.Products = FakeDatabaseOperation.products;

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            EditProductViewModel model = new EditProductViewModel
            {
                Product = FakeDatabaseOperation.getProductById(id),
                AllCategories = FakeDatabaseOperation.categories,
                
            };
            ViewData["Patlangacs"] = FakeDatabaseOperation.patlangacs;
            ViewBag.title = "Ürün Güncelle";
            return View(model);
        }
       

        public ActionResult Edit(Product product, List<int> PatlangacValue)
        {
            FakeDatabaseOperation.UpdateProduct(product, PatlangacValue);


            return RedirectToAction("Index", "Product");

        }


        public ActionResult Delete ()
        {
            int id = Convert.ToInt32(Request.QueryString["productid"]);
            string name = Request.QueryString["name"].ToString();
            FakeDatabaseOperation.DeleteProduct(id);

            return Redirect("/Product/Index");
            
        }   
        public ActionResult Delete_Path2 (int productid, string name)
        {

            FakeDatabaseOperation.DeleteProduct(productid);

            return Redirect("/Product/Index");
        }
         [HttpGet]
        public ActionResult Add()
        {
            EditProductViewModel model = new EditProductViewModel
            {
                Product = null,

                AllCategories = FakeDatabaseOperation.categories,

            };

            ViewData["Patlangacs"] = FakeDatabaseOperation.patlangacs;
            ViewBag.title = "Yeni ürün";

            return View("/Views/Product/Edit.cshtml", model  );
        }
        [HttpPost]
        public ActionResult Add(Product product, List<int> PatlangacValue)
        {
            FakeDatabaseOperation.AddProduct(product, PatlangacValue);
            return Redirect("/Product/Index");
        }
    }
}