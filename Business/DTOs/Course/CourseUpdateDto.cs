namespace Business.DTOs.Course
{
    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
    }
}
