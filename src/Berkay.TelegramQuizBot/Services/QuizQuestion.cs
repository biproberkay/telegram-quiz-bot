namespace Telegram.Bot.Services
{
    public class QuizQuestion
    {
        public string rawQuestion { get; set; } = "soru";
        public List<QuestionSelection> selection { get; set; } = new();
        public List<int> answers { get; set; } = new();
        public string status { get; set; } = "idle";
    }
    
    public class QuestionSelection
    {
        public string rawOption { get; set; } = "option";
        public string status { get; set; } = "idle";
    }
}