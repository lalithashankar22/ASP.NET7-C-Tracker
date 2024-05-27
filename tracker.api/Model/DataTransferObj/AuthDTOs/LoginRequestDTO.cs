using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.DataTransferObj.AuthDTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userid {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }    
    }
}
