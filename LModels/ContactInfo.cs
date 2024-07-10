

namespace LModels
{
	public class ContactInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactID { get; set; }

		[Required(ErrorMessage = "Branch name is required")]
		public string BranchName { get; set; }    // Tên chi nhánh

		[Required]
		public string Address { get; set; }

		[Required]
		[Phone]
		[RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Phone number must start with 0 and be 10 to 11 digits long.")]
		public string Phone { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
