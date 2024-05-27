using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tracker.web.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userid { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    public class response
    {
        public string jwtToken { get; set; }
    }

    public class return1 
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userid { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string jwt { get; set; }
    }
}
