using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallSpawner
    {
        private readonly Ball prefab;

        public BallSpawner(Ball prefab)
        {
            this.prefab = prefab;
        }

        public Ball Create(Vector3 position, bool hasPhysics = true) //TODO config
        {
            Ball ball = GameObject.Instantiate(prefab, position, Quaternion.identity);
            ball.Init();
            ball.EnablePhysics(hasPhysics);
            return ball;
        }
    }
}