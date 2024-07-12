

namespace LModels
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
