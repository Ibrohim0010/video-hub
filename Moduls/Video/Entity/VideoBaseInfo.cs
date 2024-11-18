namespace VideoHub.Moduls.Video;

public readonly record struct VideoBaseInfo(
    string Title,
    bool IsPaid,
    string Description,
    IFormFile? File);