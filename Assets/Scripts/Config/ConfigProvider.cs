using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class ConfigProvider
    {
        public Ball BallPrefab { get; private set; }

        private readonly List<BallConfig> ballConfigs;

        public ConfigProvider(List<BallConfig> ballConfigs, Ball ballPrefab)
        {
            this.ballConfigs = ballConfigs;
            this.BallPrefab = ballPrefab;
        }

        public BallConfig GetRandomBallConfig()
        {
            return ballConfigs[Random.Range(0, ballConfigs.Count)];
        }
    }
}