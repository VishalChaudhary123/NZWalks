using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRespository _imageRespository;

        public ImagesController(IImageRespository imageRespository)
        {
            _imageRespository = imageRespository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO requestDTO)
        {
            ValidateFileUpload(requestDTO);
            if (ModelState.IsValid) {


                // Map DTO to Domain Model 

                var imageDomainModel = new Image
                {
                    File = requestDTO.File,
                    FileDescription = requestDTO.FileDescription,
                    FileExtension = Path.GetExtension(requestDTO.File.FileName),
                    FileSizeInBytes = requestDTO.File.Length,
                    FileName = requestDTO.FileName,

                    // FilePath will be added in respository

                };


                // User repository to upload the image

                 await  _imageRespository.Upload(imageDomainModel);

                return Ok(imageDomainModel);

            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDTO requestDTO)
        {
            var allowedExtesions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtesions.Contains(Path.GetExtension(requestDTO.File.FileName)) )
            {
                ModelState.AddModelError("File", "Unsopported file extenisons.");
            }

            // 10 MB

            if (requestDTO.File.Length > 10485760) {

                ModelState.AddModelError("File", "File size is more than 10 MB.");
            }
        }
    }
}
