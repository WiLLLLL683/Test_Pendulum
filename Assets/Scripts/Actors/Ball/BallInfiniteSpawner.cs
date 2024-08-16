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

        [Inject]
        public void Init(ConfigProvider configProvider, BallFactory ballFactory)
        {
            this.configProvider = configProvider;
            this.ballFactory = ballFactory;
        }

        private void Update()
        {
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
            ballFactory.CreateRandom(configProvider.BallWithTimerPrefab, new(x, y), true);
        }
    }
}
