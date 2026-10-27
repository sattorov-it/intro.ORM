using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BookRepositories : IBookRepositories
{
    public void AddBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = @"insert into books(title, publishedyear, totalcopies) values
        (@title, @publishedyear, @totalcopies)";
        conn.Execute(query, book);

    }
    public void UpdateBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update books set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        conn.Execute(query, book);
    }

    public void DeleteBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from books where id = @id";
        conn.Execute(query, new { id });
    }

    public Book GetBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select * from books where id = @id";
        var book = conn.QuerySingle<Book>(query, new { id });
        return book;
    }

    public List<Book> GetBooks()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select * from books";
        return conn.Query<Book>(query).ToList();
    }

}
