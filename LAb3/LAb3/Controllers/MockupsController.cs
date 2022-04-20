using Microsoft.AspNetCore.Mvc;
using LAb3.Models;
namespace LAb3.Controllers
{
    public class MockupsController : Controller
    {
        static Quiz quiz = new();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Quiz(int? Answer, string Action)
        {
            if (Answer != null)
                quiz.AddUserAnswer((int)Answer);

            if (Action == "Finish")
                return RedirectToAction("QuizResult");

            if (Action != "Next")
            {
                quiz.ClearQuiz();
            }

            //int question = quiz.QuesNumber();
            quiz.CreateQuestion();
            ViewData["Num1"] = quiz.Number1[quiz.QuestionNumber];
            ViewData["Num2"] = quiz.Number2[quiz.QuestionNumber];
            ViewData["Oper"] = quiz.Operation[quiz.QuestionNumber];

            return View();
        }
        public IActionResult QuizResult()
        {
            if (quiz.IsValid())
            {
                ViewData["QuizValid"] = true;
                ViewData["Num1"] = quiz.Number1;
                ViewData["Num2"] = quiz.Number2;
                ViewData["Oper"] = quiz.Operation;
                ViewData["UserAnswers"] = quiz.UserAnswer;
                ViewData["CorrectAnswersAmount"] = quiz.CorrectAnswersAmount();
                ViewData["QuestionsAmount"] = quiz.QuestionNumber + 1;
            }
            else
                ViewData["QuizValid"] = false;
            return View();
        }
    }
}
