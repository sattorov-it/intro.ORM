using Domain.Models;
using Infrastructure.Repositories;

var repo = new BookRepositories();

while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"--- BOOKS MENU ---
1) Show All Books.
2) Show book by id.
3) Add new book.
4) Update book.
5) Delete book.
0) Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        case "1":
            var books = repo.GetBooks();
            foreach (var b in books)
            {
                System.Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear + " " + b.TotalCopies);
            }
            break;
        case "2":
            System.Console.Write("Enter id --> ");
            var id = Convert.ToInt32(Console.ReadLine());
            var bb = repo.GetBook(id);
            System.Console.WriteLine(bb.Id + " " + bb.Title + " " + bb.PublishedYear + " " + bb.TotalCopies);
            break;
        case "3":
            System.Console.Write("Enter Title --> ");
            var t = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var py = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var tc = Convert.ToInt32(Console.ReadLine());
            var bbb = new Book()
            {
                Title = t,
                PublishedYear = py,
                TotalCopies = tc
            };
            repo.AddBook(bbb);
            break;
        case "4":
            System.Console.Write("Enter Id --> ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Title --> ");
            var ut = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var upy = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var utc = Convert.ToInt32(Console.ReadLine());
            var ubbb = new Book()
            {
                Id = uid,
                Title = ut,
                PublishedYear = upy,
                TotalCopies = utc
            };
            repo.UpdateBook(ubbb);
            break;
        case "5":
            System.Console.Write("Enter id --> ");
            var did = Convert.ToInt32(Console.ReadLine());
            repo.DeleteBook(did);
            break;





























            
        case "0":
            System.Console.WriteLine("Exiting....");
            return;
    }
}