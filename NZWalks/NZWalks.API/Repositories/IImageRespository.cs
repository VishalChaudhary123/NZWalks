using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IImageRespository
    {
        Task<Image> Upload(Image image);    
    }
}
