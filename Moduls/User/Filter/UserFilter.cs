using VideoHub.Common.Filter;

namespace VideoHub.Moduls.User;

public record UserFilter(
    string? FullName,
    int? Age,
    string? Email):BaseFilter;