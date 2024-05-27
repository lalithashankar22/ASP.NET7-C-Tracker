using Microsoft.EntityFrameworkCore;
using tracker.api.data;
using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        //*******************************************************************************//
        //using contructor injection , im injectinf db context here 

        private readonly trackerDbContext dbcontext;

        public SQLEmployeeRepository(trackerDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //*******************************************************************************//

        public async Task<employee?> getemployeebyIdAsync(string id)
        {
            return await dbcontext.employees.FirstOrDefaultAsync(x => x.emp_id == id);
        }
        //*******************************************************************************//
        public async Task<List<employee>?> getEmployeesAsync()
        {
            return await dbcontext.employees.ToListAsync();
        }
        //*******************************************************************************//
        public async Task<employee> inseremployeeAsync(employee emp)
        {
           await dbcontext.employees.AddAsync(emp);
            await dbcontext.SaveChangesAsync();    
            return emp;
        }

    }
}
