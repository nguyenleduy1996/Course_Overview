using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Data;
using LModels;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Areas.Admin.Service
{
    public class CourseDetailService : ICourseDetailRepository
    {
        private readonly DatabaseContext _dbContext;
        public CourseDetailService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(CourseDetail courseDetail)
        {
            _dbContext.CourseDetails.Add(courseDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var courseDetail = await _dbContext.CourseDetails.FindAsync(id);
            if (courseDetail != null)
            {
                _dbContext.CourseDetails.Remove(courseDetail);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseDetail>> GetAllAsync()
        {
            return await _dbContext.CourseDetails.ToListAsync();
        }

        public async Task<IEnumerable<CourseDetail>> GetByCourseIdAsync(int courseId)
        {
            return await _dbContext.CourseDetails
               .Where(cd => cd.CourseID == courseId)
               .ToListAsync();
        }

        public async Task<CourseDetail> GetByIdAsync(int id)
        {
            return await _dbContext.CourseDetails.FindAsync(id);
        }

        public async Task UpdateAsync(CourseDetail courseDetail)
        {
            _dbContext.CourseDetails.Update(courseDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
