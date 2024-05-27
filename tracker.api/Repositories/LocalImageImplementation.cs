using Microsoft.EntityFrameworkCore;
using tracker.api.data;
using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public class LocalImageImplementation : ImageInterface
    {
        private readonly trackerDbContext dbcontext;

        public readonly IHttpContextAccessor HttpContextAccessor;

        private readonly IWebHostEnvironment webhost;

        public LocalImageImplementation(IWebHostEnvironment webHostEnviroinment , trackerDbContext dbcontext, IHttpContextAccessor HttpContextAccessor)
        {
            this.webhost = webHostEnviroinment;
            this.dbcontext = dbcontext;
            this.HttpContextAccessor = HttpContextAccessor;
        }
        public async Task<images> uploadImg(images img)
        {
           var localFilePath = Path.Combine(webhost.ContentRootPath,"Images", $"{ img.FileName}{img.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create); 
            await img.File.CopyToAsync(stream); //uploads image
           
            // since image is uploaded in repository to take the path from running application Sneed to provide the hosting path like below
            //https://localhost:1234/images/image.jpg
            var urlpath = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host}{HttpContextAccessor.HttpContext.Request.PathBase}/Images/{img.FileName}{img.FileExtension}";
            img.FilePath = urlpath;

            //add images to the image table
            await dbcontext.images.AddAsync(img);
            await dbcontext.SaveChangesAsync();
            return img;

        }
    }
}
