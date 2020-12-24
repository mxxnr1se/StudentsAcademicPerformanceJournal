using System.Collections.Generic;

namespace DAL.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public decimal AvgScore;
        
        public ICollection<Rating> Ratings { get; set; }
        
    }
}