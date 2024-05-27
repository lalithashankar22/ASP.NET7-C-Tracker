using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tracker.api.Model.domain;

namespace tracker.api.Model
{
    public class dailyTracker
    {
        [Key]
        public int track_id { get; set; }

        public double hours { get; set;}

        public DateTime start_dt { get; set;}

        public DateTime? end_dt { get; set; }

        public DateTime last_modif { get; set; }

        public char archv_flag { get; set; }

        public string? comments { get; set; }

        public int product { get; set; }

        public int work { get; set; }

        public string employee_id { get; set; }


    }
}
