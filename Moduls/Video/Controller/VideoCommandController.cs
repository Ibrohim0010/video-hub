using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoHub.Common.Controllers;
using VideoHub.Common.Extentions;
using VideoHub.Common.Result;
using VideoHub.Moduls.Video.Commands;

namespace VideoHub.Moduls.Video.Controller;

[Route("/api/videos")]
public class VideoCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVideoRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteVideoRequest(id));
        return result.ToActionResult();
    }
}