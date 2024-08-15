using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class LocalImageRespository : IImageRespository
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // Provide the running mode
        private readonly IHttpContextAccessor _contextAccessor; // Provides URL and HTTP Requests
        private readonly NZWalksDbContext _db;

        public LocalImageRespository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext db)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = httpContextAccessor;
            _db = db;
        }
        public async Task<Image> Upload(Image image)
        {
            // Gets the location
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}" );

            // Reads the file and its location
            using var stream = new FileStream(localFilePath,FileMode.Create);

            // 
            await image.File.CopyToAsync(stream);

            // _contextAccessor.HttpContext.Request.Scheme  - https://localhost:1234/Images/image.jgp
            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            // Add the image to Images table

           await _db.Images.AddAsync(image);
            await _db.SaveChangesAsync();
            return image;



        }
    }
}
