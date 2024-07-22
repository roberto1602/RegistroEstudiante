namespace Entities.Model
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public double Credit { get; set; }

        public int CareerId { get; set; }
    }
}
