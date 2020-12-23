namespace DAL.Entities
{
    public class Rating : BaseEntity
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        public decimal Score { get; set; }
    }
}