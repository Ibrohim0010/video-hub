namespace VideoHub.Moduls.Video.FileService;

public interface IFileService
{
    string CreateFile(IFormFile file,string folder);
    bool DeleteFile(string file,string folder);
}