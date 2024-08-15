using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace Test_Pendulum
{
    public class Pendulum : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private float maxAngle;
        [SerializeField] private float speed;

        private BallSpawner ballSpawner;
        private Ball ball;

        [Inject]
        public void Init(BallSpawner ballSpawner)
        {
            this.ballSpawner = ballSpawner;

            SpawnBall(ballSpawner);
        }

        private void Update()
        {
            Rotate();
            MoveBall();
        }

        private void SpawnBall(BallSpawner ballSpawner)
        {
            ball = ballSpawner.Create(endPoint.position, false);
        }

        private void ReleaseBall()
        {
            if (ball == null)
                return;

            ball.EnablePhysics(true);
            ball = null;
        }

        private void Rotate()
        {
            float angle = maxAngle * Mathf.Sin(Time.time * speed);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }

        private void MoveBall()
        {
            if (ball == null)
                return;

            ball.EnablePhysics(false);
            ball.SetPosition(endPoint.position);
        }
    }
}