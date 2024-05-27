using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tracker.api.data;
using tracker.api.Model;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        //*******************************************************************************//
        //using contructor injection , im injectinf db context here 
        private readonly trackerDbContext dbcontetxt;
        public ProjectController(trackerDbContext dbContexxt)
        {
            this.dbcontetxt = dbContexxt;
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")] 
        public async Task<IActionResult> getallproject()
        {
            var product = await dbcontetxt.product.ToListAsync(); 
            return Ok(product);
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("{id:int}")]
        public async Task<IActionResult> getprojectbydept([FromRoute]int id)
        {
            var project = await dbcontetxt.product.FindAsync(id);
            if (project == null) 
            { 
                return NotFound();
            }
            return Ok(project);
        }
        //*******************************************************************************//
    }
}
