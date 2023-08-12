using Application;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace Presentation;

public class Program
{
    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("MainConnectionString");

        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString))
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBookService, BookService>()
            .BuildServiceProvider();

        using (var scope =  serviceProvider.CreateScope())
        {
            var bookService = scope.ServiceProvider.GetService<IBookService>();
            var book = await bookService.GetBooksAsync();

            foreach(var bookItem in book)
            {
                Console.WriteLine($"{bookItem.Id}/ {bookItem.Title}");
            }
        }
    }
}
