using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Services;
using File = System.IO.File;

namespace Berkay.TelegramQuizBot;


public class QuizService
{
    private const string Path = "csharpQuestions.json";
    private static List<QuizQuestion?>? _questions;
    public QuizService()
    {
        if(_questions == null){
            LoadQuestions();
        }
    }

    
    private void LoadQuestions()
    {
        try
        {
            string json = File.ReadAllText(Path);
            _questions = JsonSerializer.Deserialize<Dictionary<string, QuizQuestion?>>(File.ReadAllText("csharpQuiz.json"))?.Values.ToList() ?? new List<QuizQuestion?>();
        }
        catch (Exception ex)
        {
            // JSON dosyasını okuma hatası
            // Hata işleme kodunu burada gerçekleştirin
            Console.WriteLine("JSON dosyasını okuma sırasında bir hata oluştu: " + ex.Message);
        }
    }

    

}

