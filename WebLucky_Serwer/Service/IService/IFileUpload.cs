using Microsoft.AspNetCore.Components.Forms;

namespace WebLucky_Serwer.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);
    }
}
