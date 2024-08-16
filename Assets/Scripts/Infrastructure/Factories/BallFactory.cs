using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallFactory
    {
        private readonly ConfigProvider configProvider;
        private readonly ScoreService scoreService;

        public BallFactory(ConfigProvider configProvider, ScoreService scoreService)
        {
            this.configProvider = configProvider;
            this.scoreService = scoreService;
        }

        public Ball CreateRandom(Ball prefab, Vector3 position, bool hasPhysics = true) =>
            Create(prefab, position, configProvider.GetRandomBallConfig(), hasPhysics);

        public Ball Create(Ball prefab, Vector3 position, BallConfig config, bool hasPhysics = true)
        {
            Ball ball = GameObject.Instantiate(prefab, position, Quaternion.identity);
            ball.Init(config, scoreService);
            ball.EnablePhysics(hasPhysics);
            return ball;
        }
    }
}