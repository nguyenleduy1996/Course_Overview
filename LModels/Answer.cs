

namespace LModels
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public string Content { get; set; }
    }
}
