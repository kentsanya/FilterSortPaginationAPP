namespace ValidModelAPP.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; }
        public SortState PriceSort { get; }
        public SortState PublishingSort { get; }
        public SortState Current { get; set; }
        public SortViewModel(SortState sortState) 
        {
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortState == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            PublishingSort = sortState == SortState.PublishingAsc ? SortState.PublishingDesc : SortState.PublishingAsc;
            Current = sortState;
        }
    }
}
