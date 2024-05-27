using System.ComponentModel.DataAnnotations;

namespace tracker.api.Model.DataTransferObj.ImagesDTO
{
    public class imagesRequestDTO
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]  
        public string FileName { get; set; }   
        public string? FileDescription { get; set; }

    }
}
