namespace Domain;
public interface IBookRepository
{
    Task<List<Book>> GetBooksAsync();
}
