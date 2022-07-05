using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTLElectronics.Models;

namespace HTLElectronics.ViewModels
{
    public class ProductView
    {
        public Product Product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}