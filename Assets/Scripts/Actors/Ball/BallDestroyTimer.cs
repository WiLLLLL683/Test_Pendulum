using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallDestroyTimer : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        [SerializeField] private float delayMin = 4f;
        [SerializeField] private float delayMax = 6f;

        private float timer;

        private void Start()
        {
            timer = Random.Range(delayMin, delayMax);
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ball.Destroy();
            }
        }
    }
}
