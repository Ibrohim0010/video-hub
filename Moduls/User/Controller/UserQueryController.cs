using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoHub.Common.Controllers;
using VideoHub.Common.Extentions;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;
using VideoHub.Moduls.User.Queries;

namespace VideoHub.Moduls.User.Controller;

[Route("/api/users")]
public class UserQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetUserViewModel>>> response = await sender.Send(new GetUserViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetUserDetailViewModel> response = await sender.Send(new GetUserDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}