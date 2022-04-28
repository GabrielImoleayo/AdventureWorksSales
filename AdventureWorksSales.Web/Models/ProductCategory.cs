using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductCategoryView
    {
        [Display(Name = "Product ID")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Product Category Name")]
        [Required(ErrorMessage = "Invalid Category name")]
        public string Name { get; set; }

        [Display(Name = "Row GUID")]
        public System.Guid Rowguid { get; set; } = new Guid();
        [Display(Name = "Modified Date")]
        public System.DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}