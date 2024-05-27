using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public interface IEmployeeRepository
    { //interface
        Task<List<employee>?> getEmployeesAsync();
        Task<employee?> getemployeebyIdAsync(string id);
       Task<employee> inseremployeeAsync(employee emp);
    }
}
