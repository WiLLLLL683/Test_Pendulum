using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallSpawner
    {
        private readonly ConfigProvider configProvider;

        public BallSpawner(ConfigProvider configProvider)
        {
            this.configProvider = configProvider;
        }

        public Ball Create(Vector3 position, bool hasPhysics = true) //TODO config
        {
            Ball ball = GameObject.Instantiate(configProvider.BallPrefab, position, Quaternion.identity);
            ball.Init(configProvider.GetRandomBallConfig());
            ball.EnablePhysics(hasPhysics);
            return ball;
        }
    }
}