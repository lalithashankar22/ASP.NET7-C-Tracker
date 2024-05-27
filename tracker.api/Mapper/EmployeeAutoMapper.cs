using AutoMapper;
using tracker.api.Model.DataTransferObj.departmentDTO;
using tracker.api.Model.DataTransferObj.employeeDTO;
using tracker.api.Model.domain;

namespace tracker.api.Mapper
{
    public class EmployeeAutoMapper :Profile
    {
        public EmployeeAutoMapper()
        {
            CreateMap<employee,employeedto>().ReverseMap();
            CreateMap<addemployeedto,employeedto>().ReverseMap();
            //CreateMap<Department, departmentDTO>().ReverseMap();
        }
    }
}
/*
 * inside ctor -constructor 
 * 
 * CreateMap<employee,employeedto>
 * .ForMember(x => x.name,opt => opt.MapFrom(x => x.FullName))
 * .Reversemap();
 * 
 * 
 * public class userDTO
 * {
 * public string Fullname {get; set;}
 * }
 * 
 *  public class userDomain
 * {
 * public string Name {get; set;}
 * }
 * 
 * */