using Library.Models;

namespace Library.ViewModels
{
    public class BookPagingViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }

    }
}
