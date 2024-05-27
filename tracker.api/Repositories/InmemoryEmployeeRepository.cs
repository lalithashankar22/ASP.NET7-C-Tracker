using System.Collections.Generic;
using System.Diagnostics.Metrics;
using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public class InmemoryEmployeeRepository //: IEmployeeRepository
    {
        public async Task<List<employee>> getEmployeesAsync()
        {
            //return new List<employee>()
            //  { 
            //     new employee()
            //      {
            //          emp_id = 1,
            //          mail_id = "test@gmail.com",
            //          master = 'Y',
            //          admin = 'Y',
            //          archv_flag = 'N'
            //      }
            //  };

            var emplist = new List<employee>();
            var emp = new employee();
              emp.emp_id = "WRK-102";
            emp.mail_id = "test@gmail.com";
            emp.master = 'Y';
            emp.admin = 'Y';
            emp.archv_flag = 'N';
            emplist.Add(emp);
          return emplist;

        }
    }
}
