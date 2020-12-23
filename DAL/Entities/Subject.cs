using System.Collections.Generic;

namespace DAL.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        
        public ICollection<Rating> Ratings { get; set; }
    }
}