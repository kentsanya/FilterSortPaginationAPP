using Microsoft.AspNetCore.Mvc.Rendering;

namespace ValidModelAPP.Models
{
    public class FilterListViewModel
    {

        public Guid? PublishingId { get; }
        public SelectList Publishings { get; }
        public string? SelectedName { get; }
        public FilterListViewModel(List<Publishing> publishings, Guid? publishingId, string? name) 
        {
            publishings.Insert(0, new Publishing { Name = "All" });
            Publishings = new SelectList(publishings, "Id", "Name", PublishingId);
            SelectedName = name;
            PublishingId = publishingId;
        }
    }
}
