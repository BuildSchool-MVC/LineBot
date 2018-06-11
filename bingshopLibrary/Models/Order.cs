namespace bingshopLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        public int OrderID { get; set; }

        public DateTime OrderDay { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Transport { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime StatusUpdateDay { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}
