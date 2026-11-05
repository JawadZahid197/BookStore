
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" },
            new Author { Id = 2, Name = "Robert Kiyosaki", Country = "USA" }
        };

        public static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter", Price = 1500, AuthorId = 1 },
            new Book { Id = 2, Title = "Rich Dad Poor Dad", Price = 2000, AuthorId = 2 },
            new Book { Id = 3, Title = "The Casual Vacancy", Price = 1800, AuthorId = 1 }
        };

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Books = Books.Select(b => new BookCardViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Price = b.Price,
                AuthorName = Authors.FirstOrDefault(a => a.Id == b.AuthorId)?.Name ?? "Unknown"
            }).ToList();

            model.Authors = Authors;

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string title, decimal price, int authorId)
        {
            if (!string.IsNullOrWhiteSpace(title) &&
                Authors.Any(a => a.Id == authorId))
            {
                Books.Add(new Book
                {
                    Id = Books.Count == 0 ? 1 : Books.Max(b => b.Id) + 1,
                    Title = title,
                    Price = price,
                    AuthorId = authorId
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Authors.Add(new Author
                {
                    Id = Authors.Count == 0 ? 1 : Authors.Max(a => a.Id) + 1,
                    Name = name,
                    Country = country
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                Books.Remove(book);
            }

            return RedirectToAction("Index");
        }
    }
}
