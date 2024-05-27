using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tracker.api.data;
using tracker.api.Model.DataTransferObj.workDTO;
using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public class SQLWorkRepository : WorkRepository
    {
        //*******************************************************************************//
        //using contructor injection , im injectinf db context here 

        private readonly trackerDbContext dbcontext;
        private readonly IMapper mapper;

        public SQLWorkRepository(trackerDbContext dbcontext ,IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }
        //*******************************************************************************//
        // default work type ,archv_flag  is null 
        public async Task<List<workDTO>?> getAllworkAsync(string? WorkType = null, char? archv_flag = null, bool? IsNameSortOrderAsc = true , int pageNumber = 1  ,int pageSize = 1000)
        {
            var workDomain =dbcontext.work.Include("Department");
            if (!string.IsNullOrEmpty(WorkType))
            {
                workDomain = workDomain.Where(x => x.work_name.Contains(WorkType));
                //ignore the case while compares
                //workDomain = workDomain.Where(x => x.work_name.Equals(WorkType,StringComparison.OrdinalIgnoreCase)); 
            }
            if (archv_flag is not null)
            {
                workDomain = workDomain.Where(x => x.archv_flag.Equals(archv_flag));
            }
            // IsNameSortOrderAsc ?? true ? --> converting bool? -> bool
            workDomain = IsNameSortOrderAsc ?? true ? workDomain.OrderBy(x => x.work_name) : workDomain.OrderByDescending(x => x.work_name);

            //paging 
            int skipCount = (pageNumber - 1) * pageSize;
            // workDomain = workDomain.Skip(skipCount); // commented sql db not compatable 
            workDomain = workDomain.Take(pageSize);

            var workdto = await workDomain.ToListAsync();
            var workdto1 = mapper.Map<List<workDTO>>(workdto);
            return workdto1;
        }
        //*******************************************************************************//
        public async Task<workDTO?> GetWorkByIdAsync(int ID)
        {
          var workDomain =  await dbcontext.work.Where(x => x.archv_flag == 'N' && x.work_id == ID).Include("Department").FirstOrDefaultAsync();
            var workdto = mapper.Map<workDTO>(workDomain);
            return workdto;
        }
       //*******************************************************************************//
        public async Task<workDTO?> UpadateWorkItemAsync(int id, UpdateWorkDTO newWorkItem)
        {
            var WorkItem = mapper.Map<Work>(newWorkItem);
            var OldWorkItem = await dbcontext.work.FindAsync(id);
            if (OldWorkItem != null)
            {
                if( (OldWorkItem.work_name != WorkItem.work_name) && (!string.IsNullOrEmpty(WorkItem.work_name)) )
                {
                    OldWorkItem.work_name = WorkItem.work_name; 
                }
                if ((OldWorkItem.start_dt != WorkItem.start_dt) && (WorkItem.start_dt.ToString() != "01/01/0001 12:00:00 AM"))
                {
                    OldWorkItem.start_dt = WorkItem.start_dt;
                }
                if((OldWorkItem.end_dt != WorkItem.end_dt) && (WorkItem.end_dt is not null))
                {
                    OldWorkItem.end_dt = WorkItem.end_dt;   
                }
                if ((OldWorkItem.archv_flag != WorkItem.archv_flag) &&  WorkItem.archv_flag != '\0')
                {
                    OldWorkItem.archv_flag = WorkItem.archv_flag;   
                }
                if ((OldWorkItem.Department_id != WorkItem.Department_id) && (WorkItem.Department_id != 0))
                {
                    OldWorkItem.Department_id = WorkItem.Department_id; 
                }
            }
            await dbcontext.SaveChangesAsync();
            var workdto = mapper.Map<workDTO>(OldWorkItem);
            return workdto;
        }
      //*******************************************************************************//
        public async Task<workDTO> AddWorkItemAsync(AddWorkDTO NewWorkItem)
        {
            var work = mapper.Map<Work>(NewWorkItem);
            await dbcontext.work.AddAsync(work);
            await dbcontext.SaveChangesAsync();

            return mapper.Map<workDTO>(work);
        }
        //*******************************************************************************//
        public  async Task<workDTO?> DeleteWorkItem(int id)
        {
            var work1 = await dbcontext.work.FindAsync(id); 
            if (work1 == null)
            {
                return null;
            }
            dbcontext.work.Remove(work1);
            await dbcontext.SaveChangesAsync();
            return mapper.Map<workDTO>(work1);
        }
        //*******************************************************************************//
    }
}
