namespace DataLayer.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TasksAndTag
    {
        public int ID { get; set; }

        public int TagId { get; set; }

        public int TaskId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
