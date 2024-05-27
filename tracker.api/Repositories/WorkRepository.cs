using tracker.api.Model.DataTransferObj.workDTO;
using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public interface WorkRepository
    {

        Task<List<workDTO>?> getAllworkAsync(string? WorkType = null ,char? archv_flag = null,bool? IsNameSortOrderAsc = true , int pageNumber = 1, int pageSize = 1000 );
        Task<workDTO?> GetWorkByIdAsync(int ID);
        Task<workDTO> AddWorkItemAsync(AddWorkDTO NewWorkItem);
        Task<workDTO?> UpadateWorkItemAsync(int id , UpdateWorkDTO WorkItem);
        Task<workDTO?> DeleteWorkItem(int id);
    }
}
