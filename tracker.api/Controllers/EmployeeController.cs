using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using tracker.api.data;
using tracker.api.Model.DataTransferObj;
using tracker.api.Model.DataTransferObj.employeeDTO;
using tracker.api.Model.domain;
using tracker.api.Repositories;

namespace tracker.api.Controllers
{
    //http://localhost/api/employee
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly trackerDbContext dbconteet;
        private readonly IEmployeeRepository employeerepository;
        private readonly IMapper automap;

        //*******************************************************************************//
        //using contructor injection , im injectinf db context employee repository , auto mappper here 

        public EmployeeController(trackerDbContext dbContexxt , IEmployeeRepository employeerepository,IMapper automap)
        {
            this.dbconteet = dbContexxt;
            this.employeerepository = employeerepository;
            this.automap = automap;
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        //Async program // multiple thread can run , main thread wont wait  
        //async -task
        // await - use async functions only
        public async Task<IActionResult> getEmployees()
        {
            // string employee = "lalitha";
            //domain model object
            //// .Where to reduce apply the condition and can give multiple condition && by useing mutiple oprator
            //  var emplist = dbconteet.employees.Where(x => x.emp_id == 4).ToList();  //directly fetching the data ffrom database 
            // var emplist = await dbconteet.employees.ToListAsync(); //after async await 

            //getting the value from db  via repository 
            var emplist = await employeerepository.getEmployeesAsync();
           
            //linkq querry 
             var data = await (from emp in dbconteet.employees
                        join dt in dbconteet.dailyTracker on emp.emp_id equals dt.employee_id
                               where emp.emp_id == "WRK-101"
                        select new
                        {
                            test = emp, //test contains all column value s
                            test1 = dt.track_id // test 1 contains only track_id value 
                        }).ToListAsync();
            /*
            //mapping to dto data transfer object 
            //initialized 
            var dtoemployee = new List<employeedto>();
            //assigning value for the list 
            foreach (var employee in emplist)
            {
                dtoemployee.Add(new employeedto()
                {
                   // assining value for the each element by initialization itself 
                    emp_id = employee.emp_id,
                    mail_id = employee.mail_id,
                    admin = employee.admin,
                    master = employee.master,
                    archv_flag = employee.archv_flag
                });
            }
            */

            //auto mapping 
            var dtoemployee = automap.Map<List<employeedto>>(emplist);
            return Ok(dtoemployee);

        }
        //*******************************************************************************//
        //[HttpGet]
        //[Route("{id:char}")]
        //public IActionResult getEmployeesbydept([FromRoute]char id)
        //{
        //    // string employee = "lalitha";

        //    var emplist = dbconteet.employees.FirstOrDefault(x=>x.archv_flag == id);
        //    return Ok(emplist);

        //}

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("get-employee")]
        //****************Sync program , main thread will wait 
        public async Task<IActionResult> getEmployeebyid([FromHeader] string id)
        {
            //demain
            //var employee = dbconteet.employees.Find(id);
          //  var employee = dbconteet.employees.FirstOrDefault(x => x.emp_id == id);

            var employee = await employeerepository.getemployeebyIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            //dto
            var dtoemployee = new employeedto()
            {
                emp_id = employee.emp_id,
                mail_id = employee.mail_id,
                admin = employee.admin,
                master = employee.master,
                archv_flag = employee.archv_flag
            };

            return Ok(dtoemployee);
        }

        //*******************************************************************************//

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> addemployee([FromBody] addemployeedto addemployee)
        {
            //received in the form of addemployeedto mapping to domain model employee 

            //initialized 
          /*  var empdomainmodel = new employee();
            //assign separately 
            empdomainmodel.mail_id = addemployee.mail_id;
            empdomainmodel.admin = addemployee.admin;
            empdomainmodel.master = addemployee.master;
          empdomainmodel.Department = depatment;
            empdomainmodel.archv_flag = 'Y';

            */
            //auto map 
            //dto -> domain
            var empdomainmodel = automap.Map<employee>(addemployee);

           await  employeerepository.inseremployeeAsync(empdomainmodel);
            // await dbconteet.employees.AddAsync(empdomainmodel);
            //await dbconteet.SaveChangesAsync();

            // 1 st param [nameof(getEmployeebyid)] - specifies the method route explicitily  even tho it is null it will find the method to get the data 
            // 2 nd param [new { id = empdomainmodel.emp_id }] -  input for the method even we pass null into it ,it will fetch the data 
            // return CreatedAtAction(nameof(getEmployeebyid), new { id = empdomainmodel.emp_id }, empdomainmodel);
            return CreatedAtAction(null, null, empdomainmodel);
        }

        //*******************************************************************************//

        [HttpPut]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> updateemp([FromHeader]string id, [FromBody] updateEmpDto updateEmp)
        {
            //emp holds value from db 
           var emp = await dbconteet.employees.Where(x=>x.emp_id == id && x.archv_flag == 'N').FirstOrDefaultAsync();
            if (emp == null) 
            {
                return NotFound();
            }
             if (updateEmp.mail_id != emp.mail_id) 
            {
                emp.mail_id = updateEmp.mail_id;
            }
             if(updateEmp.admin !=  emp.admin)
            {
                emp.admin = updateEmp.admin;    
            }
             if(updateEmp.master != emp.master)
            {
                emp.master = updateEmp.master;
            }
             if(updateEmp.archv_flag != emp.archv_flag)
            {
                emp.archv_flag = 'Y';
            }

           await dbconteet.SaveChangesAsync();
            /*
            var empreturn = new employeedto();

            empreturn.emp_id = emp.emp_id;  
            empreturn.mail_id=emp.mail_id;
            empreturn.admin = emp.admin;
            empreturn.master = emp.master;
            empreturn.archv_flag=emp.archv_flag;
            */

            //auto map 
            var empreturn = automap.Map<addemployeedto>(emp);


            return Ok(empreturn);
        }

        //*******************************************************************************//

        [HttpDelete]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> deleteemp([FromHeader] int empid)
        {
            // FindAsync will return the values matches the primary key in the table (we are using await - so also using sync)
            var emp =  await dbconteet.employees.FindAsync(empid);
           
            // employee not found return 404
            if (emp == null)
            {
                return NotFound();
            }

            // remove remployee (we dont have async for remove)
            dbconteet.employees.Remove(emp);
            // saves the changes to Data base (we are using await - so also using sync)
            await dbconteet.SaveChangesAsync();

            /* 
             //mapping  domain -> dto 
            var empreturn = new employeedto();

            empreturn.emp_id = emp.emp_id;
            empreturn.mail_id = emp.mail_id;
            empreturn.admin = emp.admin;
            empreturn.master = emp.master;
            empreturn.archv_flag = emp.archv_flag;
            */

            //automap  domain -> dto 
            //automap.Map<target type>(variable having value (from type domain));
            var empreturn = automap.Map<employeedto>(emp);
            return Ok(empreturn);
        }
        //*******************************************************************************//
    }
}
