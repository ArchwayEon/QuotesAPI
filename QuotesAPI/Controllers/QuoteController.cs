﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Models.Entities;
using QuotesAPI.Services;
using System.Drawing;

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

    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var quote = await _quoteRepo.ReadAsync(id);
        if (quote == null)
        {
            return NotFound();
        }
        return Ok(quote);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromForm] Quote quote)
    {
        if(String.IsNullOrWhiteSpace(quote.TheQuote) || 
            String.IsNullOrEmpty(quote.WhoSaidIt))
        {
            return BadRequest("The quote is badly formatted!");
        }
        await _quoteRepo.CreateAsync(quote);
        return CreatedAtAction("Get", new { id = quote.Id }, quote);
    }

}
