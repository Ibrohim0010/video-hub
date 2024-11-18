using Microsoft.AspNetCore.Mvc;
using VideoHub.Common.Extentions;

namespace VideoHub.Common.Controllers;

[ApiController]
[ApiConventionType(typeof(ApiConventions))]
public class BaseController : ControllerBase
{
    protected string? GetErrorMessage
    {
        get
        {
            return ModelState.IsValid
                ? null
                : string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
        }
    }
}