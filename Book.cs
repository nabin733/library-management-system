public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public bool IsBorrowed { get; set; }
    public string? BorrowedBy { get; set; }
}