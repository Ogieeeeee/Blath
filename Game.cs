using Blath.Enums;
using Microsoft.AspNetCore.Components.Web;

namespace Blath
{
    public class Game : IGame
    {
        private readonly Random r;
        private int _number1;
        public int Number1
        {
            get
            {
                return _number1;
            }
        }

        private int _number2;
        public int Number2
        {
            get
            {
                return _number2;
            }
        }

        public int? UserAnswer { get; set; }
        public int Score { get; set; }
        public Difficulty Difficulty { get; set; }

        public Game()
        {
            r = new Random();
        }
        public void Start()
        {
            Difficulty = Difficulty.Easy; // For now set the difficulty standard to easy
            GenerateQuestion();
        }

        public void Stop()
        {
            Score = 0;
        }

        public void CheckUserAnswer()
        {
            if (UserAnswer == _number1 + _number2)
            {
                Score++;
                GenerateQuestion();
                UserAnswer = null;
            }
            else
            {
                Stop();
            }
        }
        public void GenerateQuestion()
        {

            switch (Difficulty)
            {
                case Difficulty.Easy:
                    MakeQuestion(10);
                    break;

                case Difficulty.Medium:
                    MakeQuestion(20);
                    break;

                case Difficulty.Hard:
                    MakeQuestion(100);
                    break;
            }

            void MakeQuestion(int maxNumber)
            {
                _number1 = r.Next(maxNumber);
                _number2 = r.Next(maxNumber);

                if (_number1 + _number2 <= maxNumber)
                {
                    MakeQuestion(maxNumber);
                }
            }
        }

    }
}
