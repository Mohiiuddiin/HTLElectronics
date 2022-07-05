using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTLElectronics.Models
{
    public class Brand:BaseEntity
    {
        [Required]
        public string BrandName { get; set; }
        public string Description { get; set; }       
    }
}