using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTLElectronics.Interfaces;
using HTLElectronics.Models;
using HTLElectronics.ViewModels;

namespace HTLElectronics.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

    }
}