using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallSpawner
    {
        private readonly ConfigProvider configProvider;
        private readonly ScoreService scoreService;

        public BallSpawner(ConfigProvider configProvider, ScoreService scoreService)
        {
            this.configProvider = configProvider;
            this.scoreService = scoreService;
        }

        public Ball Create(Vector3 position, bool hasPhysics = true) //TODO config
        {
            Ball ball = GameObject.Instantiate(configProvider.BallPrefab, position, Quaternion.identity);
            ball.Init(configProvider.GetRandomBallConfig(), scoreService);
            ball.EnablePhysics(hasPhysics);
            return ball;
        }
    }
}