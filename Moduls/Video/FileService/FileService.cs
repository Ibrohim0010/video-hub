namespace VideoHub.Moduls.Video.FileService;

public class FileService(IWebHostEnvironment hostEnvironment) : IFileService
{
    private const long MaxFileSize = 10 * 1024 * 1024;

    private readonly HashSet<string> _allowedExtensions = new(StringComparer.OrdinalIgnoreCase)
        { ".mp4 ", ".mkv", ".hevc", ".mov" };
    public string CreateFile(IFormFile file, string folder)
    {
        if (_allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()) == false)
            throw new InvalidOperationException("Invalid file type.");

        if (file.Length > MaxFileSize)
            throw new InvalidOperationException("File size exceeds the maximum allowed size.");

        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string folderPath = Path.Combine(hostEnvironment.WebRootPath, folder);

        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        string fullPath = Path.Combine(folderPath, fileName);

        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public bool DeleteFile(string file, string folder)
    {
        string folderPath = Path.Combine(hostEnvironment.WebRootPath, folder);
        string fullPath = Path.Combine(folderPath, file);

        if (Directory.Exists(folderPath) == false) return false;
            
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return true;
        }

        return false;
    }
}