using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorReporisotories
{
    void AddAuthor(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(int id);
    Author GetAuthor(int id);
    List<Author> GetAuthors();
}