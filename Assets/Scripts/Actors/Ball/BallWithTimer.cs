using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class BallWithTimer : Ball
    {
        [SerializeField] private float destroyDelayMin = 4f;
        [SerializeField] private float destroyDelayMax = 6f;

        private float timer;

        private void OnEnable()
        {
            timer = Random.Range(destroyDelayMin, destroyDelayMax);
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy();
            }
        }
    }
}
