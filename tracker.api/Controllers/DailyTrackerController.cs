using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using tracker.api.data;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTrackerController : ControllerBase
    {
        //*******************************************************************************//
        //using contructor injection , im injectinf db context here 

        private readonly trackerDbContext dbcontetxt;
        public DailyTrackerController( trackerDbContext db)
        {
            this.dbcontetxt = db;   
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> Getalltracker() 
        {
            var tracker = await dbcontetxt.dailyTracker.ToListAsync();
            return Ok(tracker);
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("{id:int}")]
        public async Task<IActionResult> Getalltrackerbyid([FromRoute]int id)
        {
            var tracker = await dbcontetxt.dailyTracker.FindAsync(id);

            if (tracker == null)
            {
                return NotFound();
            }
            return Ok(tracker); 
        }

        //*******************************************************************************//
    }
}
