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
        IRepository<AboutPageContent> _Aboutus_Repo;

        public HomeController(IRepository<Product> productContext,
            IRepository<ProductCategory> productCategoryContext,
            IRepository<Brand> productCompanyContext,
            IRepository<AboutPageContent> Aboutus_Repo)
        {
            context = productContext;
            productCategories = productCategoryContext;
            productCompanies = productCompanyContext;
            _Aboutus_Repo = Aboutus_Repo;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            List<Brand> companies = productCompanies.Collection().ToList();
            if(Category == null)
            {
                products = context.Collection().Include(x=>x.Brand).Include(x=>x.Category).OrderBy(x => x.ProductCategoryId).ToList();
            }
            else
            {
                products = context.Collection().Where(x => x.Category.Category == Category).Include(x => x.Brand).Include(x => x.Category).ToList();
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
            AboutPageContent aboutUs = _Aboutus_Repo.Collection().FirstOrDefault();
            
            return View(aboutUs);
            
            
        }
        [HttpGet]
        public ActionResult AddAboutPage()
        {
            AboutPageContent IsExistAboutPage = _Aboutus_Repo.Collection().FirstOrDefault();
            if (IsExistAboutPage!=null)
            {
                return View(IsExistAboutPage);
            }
            else
            {
                IsExistAboutPage = new AboutPageContent();
                return View(IsExistAboutPage);
            }
            
        }
        [HttpPost]
        public ActionResult AddAboutPage(AboutPageContent aboutUs)
        {
            AboutPageContent IsExistAboutPage = _Aboutus_Repo.Collection().FirstOrDefault();

            if (ModelState.IsValid && IsExistAboutPage==null)
            {
                //aboutUs.Id = null;
                _Aboutus_Repo.Insert(aboutUs);
                _Aboutus_Repo.Commit();
                return RedirectToAction("About");
            }
            else if (ModelState.IsValid && !string.IsNullOrEmpty(IsExistAboutPage.About))
            {
                IsExistAboutPage.About = aboutUs.About;
                _Aboutus_Repo.Commit();
                return RedirectToAction("About");
            }
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
            List<ProductCategory> categories = productCategories.Collection().ToList();    
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