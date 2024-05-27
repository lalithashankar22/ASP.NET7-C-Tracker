using tracker.api.Model.domain;

namespace tracker.api.Repositories
{
    public interface ImageInterface
    {
        Task<images> uploadImg(images img);
    }
}
