using QuotesAPI.Models.Entities;

namespace QuotesAPI.Services;

public interface IQuoteRepository
{
    Task<ICollection<Quote>> ReadAllAsync();
    Task<Quote?> ReadAsync(int id);
    Task<Quote> CreateAsync(Quote newQuote);
    Task UpdateAsync(int oldId,  Quote updatedQuote);
    Task DeleteAsync(int id);
}
