using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HTLElectronics.Models;
using System.Web.Mvc;

namespace HTLElectronics.Models
{
    public class Product : BaseEntity
    {
        [Required]
        //[StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Specs { get; set; }

        [AllowHtml]
        public string Waarranty { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal WholeSalePrice { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
        [Required]
        [DisplayName("Product Category")]
        public string ProductCategoryId { get; set; }
        
        public Brand Brand { get; set; }
        [Required]
        [DisplayName("Product Brand")]
        public string BrandId { get; set; }


        public string Image { get; set; }


        public Product()
        {
            Quantity = 0;
        }

    }
}