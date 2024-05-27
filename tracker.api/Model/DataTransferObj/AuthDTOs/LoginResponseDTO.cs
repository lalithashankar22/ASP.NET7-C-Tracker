using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.DataTransferObj.AuthDTOs
{
    public class LoginResponseDTO
    {
        [Required]
        public string JWTToken { get; set; }
    }
}
