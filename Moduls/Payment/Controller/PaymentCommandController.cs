using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoHub.Common.Controllers;
using VideoHub.Common.Extentions;
using VideoHub.Common.Result;
using VideoHub.Moduls.Payment.Commands;

namespace VideoHub.Moduls.Payment.Controller;

[Route("/api/payments")]
public class PaymentCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeletePaymentRequest(id));
        return result.ToActionResult();
    }
}