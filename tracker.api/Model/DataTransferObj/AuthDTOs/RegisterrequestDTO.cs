using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.DataTransferObj.AuthDTOs
{
    public class RegisterrequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
