using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.domain
{
    public class Product
    {
        [Key]
        public int prod_id { get; set; }

        public string prod_name { get; set; }

        public DateTime start_dt { get; set; }

        public DateTime? end_dt { get; set; }

        public char archv_flag { get; set; }

        public int Department_id { get; set; }
    }
}
