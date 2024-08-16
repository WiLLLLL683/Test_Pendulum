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
        [SerializeField] private float ballSpawnDelay;

        private Input input;
        private BallFactory ballFactory;
        private ConfigProvider configProvider;
        private Ball ball;
        private float timer;
        private bool isEnabled;

        [Inject]
        public void Init(Input input, BallFactory ballFactory, ConfigProvider configProvider)
        {
            this.input = input;
            this.ballFactory = ballFactory;
            this.configProvider = configProvider;

            input.OnRelease += ReleaseBall;
        }

        private void OnDestroy()
        {
            input.OnRelease -= ReleaseBall;
        }

        private void Update()
        {
            if (!isEnabled)
                return;

            timer -= Time.deltaTime;

            Rotate();
            SpawnBall();
            MoveBall();
        }

        public void Enable() => isEnabled = true;
        public void Disable() => isEnabled = false;

        private void SpawnBall()
        {
            if (ball != null)
                return;
            if (timer > 0)
                return;

            ball = ballFactory.CreateRandom(configProvider.BallPrefab, endPoint.position, false);
        }

        private void ReleaseBall()
        {
            if (ball == null)
                return;

            ball.EnablePhysics(true);
            ball = null;
            timer = ballSpawnDelay;
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