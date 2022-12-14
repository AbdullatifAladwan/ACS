namespace Task.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("task")]
    public partial class task
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        public double actual_cost { get; set; }

        public double total_budget { get; set; }

        public double budget_variance { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [StringLength(500)]
        public string imagepath { get; set; }

        public int? task_sub { get; set; }

        public int? sub { get; set; }

        public virtual sub_task sub_task { get; set; }

        public virtual user user { get; set; }
    }
}
