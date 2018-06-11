namespace bingshopLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product Photo")]
    public partial class Product_Photo
    {
        [Key]
        public int PhotoID { get; set; }

        public int ProductID { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        public virtual Products Products { get; set; }
    }
}
