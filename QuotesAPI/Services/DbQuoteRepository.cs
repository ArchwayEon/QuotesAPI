using Microsoft.EntityFrameworkCore;
using QuotesAPI.Models.Entities;

namespace QuotesAPI.Services;

public class DbQuoteRepository : IQuoteRepository
{
    private readonly ApplicationDbContext _db;

    public DbQuoteRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Quote?> ReadAsync(int id)
    {
        return await _db.Quotes.FindAsync(id);
    }

    public async Task<ICollection<Quote>> ReadAllAsync()
    {
        return await _db.Quotes.ToListAsync();
    }

    public async Task<Quote> CreateAsync(Quote newQuote)
    {
        await _db.Quotes.AddAsync(newQuote);
        await _db.SaveChangesAsync();
        return newQuote;
    }
}
