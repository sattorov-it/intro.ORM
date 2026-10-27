using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepositories
{
    void AddGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void DeleteGenre(int id);
    Genre GetGenre(int id);
    List<Genre> GetGenres();
}