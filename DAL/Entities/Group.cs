using System.Collections.Generic;

namespace DAL.Entities
{
    public class Group : BaseEntity
    {
        public string Number { get; set; }
        
        public ICollection<Student> Students { get; set; }
    }
}