using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using tracker.api.Model.DataTransferObj.ImagesDTO;
using tracker.api.Model.domain;
using tracker.api.Repositories;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImageInterface imagerepo;

        public ImagesController(ImageInterface ImageRepo)
        {
            this.imagerepo = ImageRepo;
        }
        // post : /api/images/upload
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [Route("upload")]
        public async Task<IActionResult> upload([FromForm] imagesRequestDTO ImageUploadRequest)
        {
            ValidateFileUpload(ImageUploadRequest);
            if(ModelState.IsValid)
            {//convert dto to domain model 
                //repositoried only can handle domain model 
                var imagedomain = new images
                {
                    File = ImageUploadRequest.file,
                    FileExtension = Path.GetExtension(ImageUploadRequest.file.FileName),
                    FileSizeInByte = ImageUploadRequest.file.Length,
                    FileName = ImageUploadRequest.FileName,
                    FileDescription = ImageUploadRequest.FileDescription
                };
                //upload image to repository 
                await imagerepo.uploadImg(imagedomain);
                return Ok(imagedomain);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(imagesRequestDTO request)
        {
            var AllowedExtension = new string[] {".jpg",".jpeg",".png" };
            if (!AllowedExtension.Contains(Path.GetExtension(request.file.FileName))) 
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if(request.file.Length > 1048576) // binary of 1048576 is 10Mib
            {
                ModelState.AddModelError("file", "Only 10 Mibs allowed");
            }
        }
    }
}
