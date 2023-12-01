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

    public async Task UpdateAsync(int oldId, Quote updatedQuote)
    {
        Quote? quoteToUpdate = await ReadAsync(oldId);
        quoteToUpdate!.TheQuote = updatedQuote.TheQuote;
        quoteToUpdate!.WhoSaidIt = updatedQuote.WhoSaidIt;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Quote? quoteToDelete = await ReadAsync(id);
        _db.Quotes.Remove(quoteToDelete!);
        await _db.SaveChangesAsync();
    }
}
