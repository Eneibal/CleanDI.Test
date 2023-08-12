using Domain;

namespace Application;

public interface IBookService
{
    Task<List<Book>> GetBooksAsync();
}
