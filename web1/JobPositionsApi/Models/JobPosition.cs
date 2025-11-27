namespace JobPositionsApi.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal BeginningSalary { get; set; }
    }
}
