using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Test_Pendulum
{
    public class BallInfiniteSpawner : MonoBehaviour
    {
        [SerializeField] private float delayMin = 4f;
        [SerializeField] private float delayMax = 6f;
        [SerializeField] private Transform leftDownCorner;
        [SerializeField] private Transform rightTopCorner;

        private ConfigProvider configProvider;
        private BallFactory ballFactory;
        private float timer;
        private bool isEnabled;
        private List<Ball> balls = new();

        [Inject]
        public void Init(ConfigProvider configProvider, BallFactory ballFactory)
        {
            this.configProvider = configProvider;
            this.ballFactory = ballFactory;
        }

        public void Enable() => isEnabled = true;
        public void Disable() => isEnabled = false;

        public void DestroyAll()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Destroy();
            }
        }

        private void Update()
        {
            if (!isEnabled)
                return;

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = Random.Range(delayMin, delayMax);
                Spawn();
            }
        }

        private void Spawn()
        {
            float x = Random.Range(leftDownCorner.position.x, rightTopCorner.position.x);
            float y = Random.Range(leftDownCorner.position.y, rightTopCorner.position.y);
            Ball ball = ballFactory.CreateRandom(configProvider.BallWithTimerPrefab, new(x, y), true);

        }

        private void Register(Ball ball)
        {
            balls.Add(ball);
            ball.OnDestroy += Deregister;
        }

        private void Deregister(Ball ball)
        {
            ball.OnDestroy -= Deregister;
            balls.Remove(ball);
        }
    }
}
