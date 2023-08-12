using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }
}
