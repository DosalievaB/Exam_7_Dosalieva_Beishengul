using Shop.Models;

namespace Shop.ViewModels
{
    public class BookPagingViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }

    }
}
