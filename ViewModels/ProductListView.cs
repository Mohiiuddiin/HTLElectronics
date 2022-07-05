using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTLElectronics.Models;

namespace HTLElectronics.ViewModels
{
    public class ProductListView
    {
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}