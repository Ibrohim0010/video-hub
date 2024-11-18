using VideoHub.Common.Filter;

namespace VideoHub.Moduls.Video;

public record VideoFilter(
    string? Title,
    bool? IsPaid,
    string? Description):BaseFilter;