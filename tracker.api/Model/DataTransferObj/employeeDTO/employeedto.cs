using tracker.api.Model.domain;

namespace tracker.api.Model.DataTransferObj.employeeDTO
{
    public class employeedto
    {
        public string emp_id { get; set; }

        public string mail_id { get; set; }

        public string password { get; set; }

        public char admin { get; set; }

        public char master { get; set; }

        public char archv_flag { get; set; }

        public int Department_id { get; set; }

    }
}
