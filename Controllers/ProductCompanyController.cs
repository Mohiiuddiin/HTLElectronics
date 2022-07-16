using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTLElectronics.DAL.Gateway;
using HTLElectronics.Interfaces;
using HTLElectronics.Models;

namespace HTLElectronics.Controllers
{

    public class ProductCompanyController : Controller
    {

        private IRepository<Brand> repository;

        public ProductCompanyController(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        // GET: Company
        [Authorize(Roles = "Admin,Employee")]

        public ActionResult Index()
        {
            List<Brand> productCompany = repository.Collection().ToList();
            return View(productCompany);
        }
        

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]

        public ActionResult Create()
        {
            Brand productCompany = new Brand();
            return View(productCompany);
        }
        [HttpPost]
        public ActionResult Create(Brand productCompany)
        {
            if (!ModelState.IsValid)
            {
                return View(productCompany);
            }
            else
            {
                repository.Insert(productCompany);
                repository.Commit();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(string Id)
        {
            Brand productCompany = repository.Find(Id);
            if (productCompany == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCompany);
            }

        }
        [HttpPost]
        public ActionResult Edit(Brand productCompany)
        {
            if (productCompany == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCompany);
                }
                else
                {
                    repository.Update(productCompany);
                    repository.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        [Authorize(Roles = "Admin")]

        public ActionResult Delete(string Id)
        {
            Brand productCompany = repository.Find(Id);

            if (productCompany != null)
            {
                repository.Delete(Id);
                repository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}