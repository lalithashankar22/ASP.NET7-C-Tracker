using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Net;
using System.Text.Json;
using tracker.api.data;
using tracker.api.Model;
using tracker.api.Model.DataTransferObj.workDTO;
using tracker.api.Model.domain;
using tracker.api.Repositories;
using tracker.api.ValidationAttribute;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
       public class WorkController : ControllerBase
    {
        //*******************************************************************************//
        //using contructor injection , im injecting db context here 


        private readonly WorkRepository workrepository;
        private readonly ILogger<WorkController> log;

        public WorkController( WorkRepository workrepository , ILogger<WorkController> log)
        {
            this.workrepository = workrepository;
            this.log = log;
        }

        //*******************************************************************************//

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> getallwork([FromQuery]string? WorkType , [FromQuery] char? archv_flag, [FromQuery] bool? IsNameSortOrderAsc, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            log.LogInformation("get all work invoked");
            log.LogError("test error");
            log.LogWarning("test warning");
            var works = await workrepository.getAllworkAsync(WorkType, archv_flag, IsNameSortOrderAsc ,pageNumber ,pageSize);
            log.LogInformation($"returned data:{JsonSerializer.Serialize(works)}");
            return Ok(works);   
        }

        //*******************************************************************************//

        [HttpGet]
        [Route("GET-WORK-ID")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> getallworkbydept([FromHeader]int id)
        {
            //try
            ////{
                  throw new Exception("test exception");   
                var work = await workrepository.GetWorkByIdAsync(id);
            
                if (work == null)
                {
                    return NotFound();
                }
                return Ok(work);

            //}
            //catch (Exception ex)
            //{
            //    log.LogError(ex,ex.Message);
            //    return Problem("problem", null, (int)HttpStatusCode.InternalServerError);
            //    throw;
            //}
           
        }
        //*******************************************************************************//
        [HttpPost]
       [ValidationModel] ///without this attribute also it validates error
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> AddWorkItem([FromBody] AddWorkDTO NewWork)
        {
            var work1 = await workrepository.AddWorkItemAsync(NewWork);
            var work2 = await workrepository.GetWorkByIdAsync(work1.work_id);
            return CreatedAtAction(null, null,work2);
        }
        //*******************************************************************************//
        [HttpPut]
        [ValidationModel]  ///without this attribute also it validates error
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateWorkItem([FromHeader] int id ,[FromBody] UpdateWorkDTO NewWork)
        {
           var work1 =  await workrepository.UpadateWorkItemAsync(id, NewWork);
            if (work1 == null)
            {
                return NotFound();
            }
            var work = await workrepository.GetWorkByIdAsync(id);
            return Ok(work);
        }
        //*******************************************************************************//
        [HttpDelete]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> deleteWorkItem(int id)
        {
           var work = await workrepository.DeleteWorkItem(id);
            return Ok(work);
        }
        //*******************************************************************************//
    }

}
