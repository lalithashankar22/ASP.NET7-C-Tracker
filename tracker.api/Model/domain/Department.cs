using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.domain
{
    public class Department
    {
        [Key]
        public int dept_id { get; set; }

        public string dept_name { get; set; }

        public char archv_flag { get; set; }
    }
}
