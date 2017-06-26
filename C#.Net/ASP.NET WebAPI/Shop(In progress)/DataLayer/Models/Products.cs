namespace DataLayer.Model
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
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(90)]
        public string Name { get; set; }

        public int GroupId { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        [Required]
        [StringLength(1400)]
        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string ImgSrc { get; set; }

        public virtual Groups Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
