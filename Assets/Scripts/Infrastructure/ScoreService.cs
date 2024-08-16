using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class ScoreService
    {
        public int Score { get; private set; }

        public event Action<int> OnChange;

        public ScoreService(int score = 0)
        {
            Score = score;
        }

        public void Reset()
        {
            Score = 0;
            OnChange?.Invoke(Score);
        }

        public void AddPoints(int points)
        {
            if (points <= 0)
                return;

            Score += points;
            OnChange?.Invoke(Score);
        }
    }
}