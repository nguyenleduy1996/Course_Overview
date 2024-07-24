using LModels;

namespace Course_Overview.Areas.Admin.Repository
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllUser();
		Task<User> GetUserByEmailAsync(string email);
		Task AddUser(User user);
		Task UpdateUser(User user);
		Task DeleteUser(int id);
		// Lấy số lần đăng nhập thất bại cho email
		Task<int> GetFailedAttemptsAsync(string email);
	}
}
