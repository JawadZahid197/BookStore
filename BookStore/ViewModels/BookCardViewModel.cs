
namespace BookStore.ViewModels
{
    public class BookCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
