using LModels;

namespace Course_Overview.Areas.Admin.Repository
{
    public interface ICourseDetailRepository
    {
        Task<IEnumerable<CourseDetail>> GetAllAsync();
        Task<CourseDetail> GetByIdAsync(int id);
        Task<IEnumerable<CourseDetail>> GetByCourseIdAsync(int courseId);
        Task AddAsync(CourseDetail courseDetail);
        Task UpdateAsync(CourseDetail courseDetail);
        Task DeleteAsync(int id);
    }
}
