namespace Library.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set;}

        public PageViewModel(int count, int pageNumber, int PageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }
        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }
    }
}
