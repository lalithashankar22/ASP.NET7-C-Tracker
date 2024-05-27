using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tracker.api.Model.domain
{
    public class Work
    {
        [Key]
        public int work_id { get; set; }

        public string work_name { get; set; }

        public DateTime start_dt { get; set; }

        public DateTime? end_dt { get; set; }

        public char archv_flag { get; set; }

        // public Department Department_id { get; set; }
        public int Department_id { get; set; } // Foreign key

        [ForeignKey("Department_id")] // Define the foreign key relationship
        public Department Department { get; set; }
    }
}
