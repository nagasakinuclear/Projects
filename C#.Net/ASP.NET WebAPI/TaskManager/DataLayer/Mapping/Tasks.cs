namespace DataLayer.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        public int TaskId { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastModification { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
