using Microsoft.AspNetCore.Http;

namespace _0_FrameWork.Application
{
    public interface IFileUploader
    {
        string UploadFile(IFormFile file,string path);
    }
}
