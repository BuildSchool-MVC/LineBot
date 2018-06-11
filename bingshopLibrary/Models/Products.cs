namespace bingshopLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Order_Details = new HashSet<Order_Details>();
            Product_Photo = new HashSet<Product_Photo>();
            Shoppingcart_Details = new HashSet<Shoppingcart_Details>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        public DateTime Uptime { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        public string ProductDetails { get; set; }

        public DateTime? Downtime { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Photo> Product_Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shoppingcart_Details> Shoppingcart_Details { get; set; }
    }
}
