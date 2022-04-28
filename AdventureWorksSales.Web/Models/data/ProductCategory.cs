namespace AdventureWorksSales.Web.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [Key]
        [Column(Order = 0)]
        public int ProductCategoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid rowguid { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ModifiedDate { get; set; }
    }
}
