using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[StringLength(250, ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required]
		[StringLength(350, ErrorMessage = "Address is required")]
		public string Address { get; set; }

		[Required]
		[Phone]
		[RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Phone number must start with 0 and be 10 to 11 digits long.")]
		public string Phone { get; set; }
		public string? Status { get; set; }
		public string Role { get; set; }

		// Thuộc tính để lưu trữ số lần đăng nhập thất bại
		public int FailedAttempts { get; set; }
		public DateTime? LockoutEnd { get; set; } // Thời gian khóa tài khoản kết thúc
	}
}
