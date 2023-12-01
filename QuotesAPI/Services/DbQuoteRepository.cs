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

    public async Task<ICollection<Quote>> ReadAllAsync()
    {
        return await _db.Quotes.ToListAsync();
    }
}
