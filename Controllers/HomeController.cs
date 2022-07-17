using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HTLElectronics.Interfaces;
using HTLElectronics.Models;
using HTLElectronics.ViewModels;

namespace HTLElectronics.Controllers
{
    //[RequireHttps]
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        IRepository<Brand> productCompanies;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext, IRepository<Brand> productCompanyContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
            productCompanies = productCompanyContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            List<Brand> companies = productCompanies.Collection().ToList();
            if(Category == null)
            {
                products = context.Collection().Include(x=>x.Brand).ToList();
            }
            else
            {
                products = context.Collection().Where(x => x.Category.Category == Category).Include(x => x.Brand).ToList();
            }

            ProductListView productList = new ProductListView
            {
                Products = products,
                ProductCategory = categories,
                Brands = companies
            };

            return View(productList);
        }
        public ActionResult Details(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult CatNavBar(string Category = null)
        {
            //List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            //List<Brand> companies = productCompanies.Collection().ToList();
            //if (Category == null)
            //{
            //    products = context.Collection().Include(x => x.Brand).ToList();
            //}
            //else
            //{
            //    products = context.Collection().Where(x => x.Category.Category == Category).Include(x => x.Brand).ToList();
            //}

            ProductListView productList = new ProductListView
            {
                Products = null,
                ProductCategory = categories,
                Brands = null
            };
            return PartialView("_CatNavBar", productList);
        }
        public ActionResult ProductDetails(string id)
        {   
            Product product = context.Collection().Where(x => x.Id == id).Include(x => x.Brand).FirstOrDefault();
            return View(product);
        }
    }
}