using System.ComponentModel.DataAnnotations;

namespace LAb3.Models
{
    public class Quiz
    {
        public List<int> Number1 = new();
        public List<int> Number2 = new();
        public List<string> Operation = new();
        public List<int> RightAnswer = new();
        public List<int> UserAnswer = new();
        public int QuestionNumber = -1;

        public void CreateQuestion()
        {
            QuestionNumber++;
            Random rnd = new Random();
            Number1.Add(rnd.Next(0, 10));
            Number2.Add(rnd.Next(1, 10));
            int a = rnd.Next(0, 4);
            switch (a)
            {
                case 0:
                    Operation.Add("+");
                    RightAnswer.Add(Number1[QuestionNumber] + Number2[QuestionNumber]);
                    break;
                case 1:
                    Operation.Add("-");
                    RightAnswer.Add(Number1[QuestionNumber] - Number2[QuestionNumber]);
                    break;
                case 2:
                    Operation.Add("*");
                    RightAnswer.Add(Number1[QuestionNumber] * Number2[QuestionNumber]);
                    break;
                case 3:
                    Operation.Add("/");
                    RightAnswer.Add(Number1[QuestionNumber] / Number2[QuestionNumber]);
                    break;
            }
        }
        public void AddUserAnswer(int Answer)
        {
            UserAnswer.Add(Answer);
        }
        public void ClearQuiz()
        {
            Number1.Clear();
            Number2.Clear();
            Operation.Clear();
            RightAnswer.Clear();
            UserAnswer.Clear();
            QuestionNumber = -1;
        }
        public bool IsValid()
        {
            return (RightAnswer.Count == UserAnswer.Count);
        }
        public int CorrectAnswersAmount()
        {
            int amount = 0;
            for (int i = 0; i < QuestionNumber + 1; i++)
                if (RightAnswer[i] == UserAnswer[i])
                    amount++;
            return amount;
        }
    }       
}
