using AutoMapper;
using tracker.api.Model.DataTransferObj.departmentDTO;
using tracker.api.Model.DataTransferObj.workDTO;
using tracker.api.Model.domain;

namespace tracker.api.Mapper
{
    public class WorkAutoMap :Profile
    {
        public WorkAutoMap()
        {
            CreateMap<workDTO, Work>().ReverseMap();
            CreateMap<AddWorkDTO,Work>().ReverseMap();
            CreateMap<UpdateWorkDTO, Work>().ReverseMap();
        }
    }
}
