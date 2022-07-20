using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTLElectronics.Models
{
    public class AboutPageContent : BaseEntity
    {
        [AllowHtml]
        [Required]
        public string About { get; set; }
    }
}