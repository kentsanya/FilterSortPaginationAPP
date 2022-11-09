namespace ValidModelAPP.Models
{
    public class ListViewModel
    {
        public IEnumerable<Book> Books { get; }
        public PageViewModel PageViewModel { get; }
        public FilterListViewModel FilterListViewModel { get; }
        public SortViewModel SortViewModel { get; }
        public ListViewModel(IEnumerable<Book> books, PageViewModel pageViewModel, FilterListViewModel filterListViewModel, SortViewModel sortViewModel)
        {
            Books = books;
            PageViewModel = pageViewModel;
            FilterListViewModel = filterListViewModel;
            SortViewModel = sortViewModel;
        }
    }
}
