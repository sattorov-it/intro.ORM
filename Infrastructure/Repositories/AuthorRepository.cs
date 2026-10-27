using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorReporisotories
{
    public void AddAuthor(Author author)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into authors (fullname, country, birthyear) values (@fullname, @country, @birthyear)";
        connection.Execute(query, author);
    }

    public void DeleteAuthor(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"delete from authors where id = @id";
        connection.Execute(query, new { id });
    }

    public Author GetAuthor(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"select * from authors where id = @id";
        var author = connection.QuerySingle<Author>(query, new { id });
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"select * from authors";
        var author = connection.Query<Author>(query);
        return author.ToList();
    }

    public void UpdateAuthor(Author author)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        connection.Execute(query, author);
    }
}