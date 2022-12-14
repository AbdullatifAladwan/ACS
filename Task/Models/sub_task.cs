namespace Task.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sub_task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sub_task()
        {
            tasks = new HashSet<task>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(500)]
        public string imagepath { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        public double actual_cost { get; set; }

        public double total_budget { get; set; }

        public double budget_variance { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> tasks { get; set; }
    }
}
