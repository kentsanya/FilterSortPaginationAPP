using System.ComponentModel.DataAnnotations;

namespace ValidModelAPP.Models
{
    public class Book 
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Display(Name ="Name of Book")]
        public string? Title { get; set; }

        [Range(1,10000)]
        public int Price { get; set; }

        public Guid? PublishingId { get; set; }

        public Publishing? Publishing { get; set; } 
     
 
    }
}
