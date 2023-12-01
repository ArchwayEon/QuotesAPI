using Microsoft.EntityFrameworkCore;
using QuotesAPI.Models.Entities;

namespace QuotesAPI.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Quote> Quotes => Set<Quote>();
}
