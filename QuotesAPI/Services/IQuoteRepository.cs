using QuotesAPI.Models.Entities;

namespace QuotesAPI.Services;

public interface IQuoteRepository
{
    Task<ICollection<Quote>> ReadAllAsync();
}
