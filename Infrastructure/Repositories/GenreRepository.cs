using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepositories
{
    public void AddGenre(Genre genre)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into genres (name) values (@name)";
        connection.Execute(query, genre);
    }

    public void DeleteGenre(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "delete from genres where id=@id";
        connection.Execute(query, new { id });
    }

    public Genre GetGenre(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from genres where id=@id";
        var genre = connection.QuerySingle<Genre>(query, new { id });
        return genre;
    }

    public List<Genre> GetGenres()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from genres";
        return connection.Query<Genre>(query).ToList();
    }

    public void UpdateGenre(Genre genre)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "update genres set name = @name where id=@id";
        connection.Execute(query, genre);
    }
}