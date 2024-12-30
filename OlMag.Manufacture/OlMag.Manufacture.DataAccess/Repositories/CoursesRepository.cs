using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OlMag.Manufacture.DataAccess.Models;

namespace OlMag.Manufacture.DataAccess.Repositories
{
    public class CoursesRepository
    {
        private readonly LearningDbContext _dbContext;

        public CoursesRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseEntity>> Get()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .OrderBy(c=>c.Title)
                .OrderBy(c=>c.Id)
                .ToListAsync();
        }

        public async Task<List<CourseEntity>> GetWithLessons()
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Include(c=>c.Lessons)
                .ToListAsync();
        }

        public async Task<CourseEntity?> GetById(Guid id)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CourseEntity>> GetByFilter(string? title, decimal? price)
        {
            var query = _dbContext.Courses.AsNoTracking();
            if (title != null) query.Where(c => c.Title == title);
            if (price != null) query.Where(c => c.Price == price);

            return await query.ToListAsync();
        }

        public async Task<List<CourseEntity>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(CourseEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        [Obsolete]
        public async Task UpdateObsolete(CourseEntity entity)
        {
            var courseEntity = await _dbContext.Courses.FirstOrDefaultAsync() ?? throw new NotImplementedException();

            courseEntity.Title = entity.Title;
            courseEntity.Price = entity.Price;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(CourseEntity entity)
        {
            await _dbContext.Courses.Where(c=>c.Id == entity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c=>c.Title, entity.Title)
                .SetProperty(c=>c.Description, entity.Description)
                .SetProperty(c=>c.Price, entity.Price) 
                );
        }

        public async Task Delete(CourseEntity entity)
        {
            await _dbContext.Courses.Where(c => c.Id == entity.Id)
                .ExecuteDeleteAsync();
        }
    }
    public class LessonsRepository
    {
        private readonly LearningDbContext _dbContext;

        public LessonsRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public async Task AddLessonSmallBad(Guid courseId, LessonEntity lesson)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(c=>c.Id == courseId)
                ?? throw new NotImplementedException();
            course.Lessons.Add(lesson);

            await _dbContext.SaveChangesAsync();
        }
        public async Task AddLesson(Guid courseId, string lessonTitle)
        {
            var lesson = new LessonEntity
            {
                Title = lessonTitle,
                CourseId = courseId
            };

            await _dbContext.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }
    }
}
