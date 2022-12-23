using Blath.Enums;

namespace Blath
{
    public interface IGame
    {
        int Number1 { get; }
        int Number2 { get; }
        int? UserAnswer { get; set; }
        int Score { get; set; }
        Difficulty Difficulty { get; set; }
        void Start();
        void Stop();
        void GenerateQuestion();
        void CheckUserAnswer();

    }
}