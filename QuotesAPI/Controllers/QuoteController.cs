using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Services;

namespace QuotesAPI.Controllers;

[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class QuoteController : ControllerBase
{
    private readonly IQuoteRepository _quoteRepo;

    public QuoteController(IQuoteRepository quoteRepo)
    {
        _quoteRepo = quoteRepo;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _quoteRepo.ReadAllAsync());
    }

}
