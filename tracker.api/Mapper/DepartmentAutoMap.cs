using AutoMapper;
using tracker.api.Model.DataTransferObj.departmentDTO;
using tracker.api.Model.domain;

namespace tracker.api.Mapper
{
    public class DepartmentAutoMap:Profile
    {
        public DepartmentAutoMap()
        {
            CreateMap<Department,departmentDTO>().ReverseMap();
            CreateMap<Department, DepartmentAddDTOcs>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDTO>().ReverseMap();
        }
    }
}
