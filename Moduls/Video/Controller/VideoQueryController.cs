using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoHub.Common.Controllers;
using VideoHub.Common.Extentions;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;
using VideoHub.Moduls.Video.Queries;

namespace VideoHub.Moduls.Video.Controller;

[Route("/api/videos")]
public class VideoQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] VideoFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetVideoViewModel>>> response = await sender.Send(new GetVideoViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetVideoDetailViewModel> response = await sender.Send(new GetVideoDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}