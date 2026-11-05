
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; } = new List<BookCardViewModel>();
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
