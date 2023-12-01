namespace QuotesAPI.Models.Entities;

public class Quote
{
    public int Id { get; set; }
    public string TheQuote { get; set; } = String.Empty;
    public string WhoSaidIt { get; set; } = String.Empty;
}
