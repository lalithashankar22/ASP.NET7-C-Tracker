using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Data;
using tracker.api.data;
using tracker.api.Model.DataTransferObj.departmentDTO;
using tracker.api.Model.domain;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        // basic API Call 
        //*******************************************************************************//
        //using contructor injection , im injectinf db context here 

        private readonly trackerDbContext dbecontetxt;
        private readonly IMapper automap;

        public DepartmentController(trackerDbContext dbcontexxt, IMapper automap)
        {
            this.dbecontetxt = dbcontexxt;
            this.automap = automap;
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> getalldepartment()
        {
            var department = await dbecontetxt.department.ToListAsync();
            return Ok(automap.Map<List<departmentDTO>>(department));
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("{id:int}")]
        public async Task<IActionResult> getdepartmentbyid([FromRoute]int id)
        {
            var department = await dbecontetxt.department.FindAsync(id);
            if (department == null) 
            { 
               return NotFound();
            }
            return Ok(automap.Map<departmentDTO>(department));  

        }
        //*******************************************************************************//
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> adddepartment([FromBody] DepartmentAddDTOcs Department)
        {
            var deptdomain = automap.Map<Department>(Department);
            await dbecontetxt.AddAsync(deptdomain);
            await dbecontetxt.SaveChangesAsync();
            return CreatedAtAction(null,null, automap.Map<departmentDTO>(deptdomain));
        }
        //*******************************************************************************//
        [HttpPut]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> updatedepartment([FromHeader] int id,[FromBody] DepartmentUpdateDTO Department) 
        {
            //getting from DB domain model
            var olddepartment = await dbecontetxt.department.FindAsync(id);

            if (olddepartment == null)
            {
                return NotFound();  
            }

            //domain -> dto 
            var newdepartment = automap.Map<Department>(Department);

            if ((newdepartment.dept_name != olddepartment.dept_name) && !string.IsNullOrEmpty(newdepartment.dept_name))
            {
                olddepartment.dept_name = newdepartment.dept_name;
            }
            if ((newdepartment.archv_flag != olddepartment.archv_flag) && newdepartment.archv_flag != '\0')
            {
                olddepartment.archv_flag = newdepartment.archv_flag;
            }

            await dbecontetxt.SaveChangesAsync();
            return Ok(automap.Map<departmentDTO>(olddepartment));

        }
        //*******************************************************************************//
        [HttpDelete]
        [Authorize(Roles = "Writer")]
        public IActionResult deleteDepartment([FromHeader]int id)
        {
            var department = dbecontetxt.department.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            dbecontetxt.department.Remove(department);
            dbecontetxt.SaveChanges();
            return Ok(automap.Map<departmentDTO>(department));
        }

        //*******************************************************************************//
    }
}
