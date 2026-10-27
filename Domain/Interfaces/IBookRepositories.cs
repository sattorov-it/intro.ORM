using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepositories
{
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(int id);
    Book GetBook(int id);
    List<Book> GetBooks();
}
