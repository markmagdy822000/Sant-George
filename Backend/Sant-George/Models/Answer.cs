using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SantGeorgeWebsite.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Text{ get; set; }
        public bool? IsCorrect { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public QuestionType Type{ get; set; }
        
    }

    public enum QuestionType
    {
        Text, OneAnswer, MultipleAnswers
    }
}
