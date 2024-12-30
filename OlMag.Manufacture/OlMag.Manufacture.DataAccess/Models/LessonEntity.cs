namespace OlMag.Manufacture.DataAccess.Models
{
    public class LessonEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public CourseEntity? Course { get; set; }
    }
}
