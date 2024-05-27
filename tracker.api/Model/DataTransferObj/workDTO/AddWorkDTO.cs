using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tracker.api.Model.domain;

namespace tracker.api.Model.DataTransferObj.workDTO
{
    public class AddWorkDTO
    { 

        [Required]
        public string work_name { get; set; }
        
       [Range(typeof(DateTime), "0001-01-01", "2023-12-31", ErrorMessage = "Date should be today or in the past.")]
        public DateTime start_dt { get; set; }

        public DateTime? end_dt { get; set; }


        public char archv_flag { get; set; }

        public int Department_id { get; set; } // Foreign key
    }
}
