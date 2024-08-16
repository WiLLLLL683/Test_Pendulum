using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class ConfigProvider
    {
        public Ball BallPrefab { get; private set; }
        public Ball BallWithTimerPrefab { get; private set; }
        public AudioClip GameOverSound { get; private set; }

        private readonly List<BallConfig> ballConfigs;

        public ConfigProvider(List<BallConfig> ballConfigs, Ball ballPrefab, Ball ballWithTimerPrefab, AudioClip gameOverSound)
        {
            this.ballConfigs = ballConfigs;
            this.BallPrefab = ballPrefab;
            this.BallWithTimerPrefab = ballWithTimerPrefab;
            this.GameOverSound = gameOverSound;
        }

        public BallConfig GetRandomBallConfig()
        {
            return ballConfigs[Random.Range(0, ballConfigs.Count)];
        }
    }
}