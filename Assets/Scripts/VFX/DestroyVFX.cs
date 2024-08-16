using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

namespace Test_Pendulum
{
    public class DestroyVFX : MonoBehaviour
    {
        [SerializeField] private VisualEffect visualEffect;

        private ObjectPool<DestroyVFX> pool;
        private bool hasPlayed;

        public void Init(ObjectPool<DestroyVFX> pool)
        {
            this.pool = pool;
            hasPlayed = false;
        }

        public void Update()
        {
            if (visualEffect == null)
                return;

            if (visualEffect.aliveParticleCount > 0)
            {
                hasPlayed = true;
            }

            if (visualEffect.aliveParticleCount == 0 && hasPlayed)
            {
                pool.Release(this);
            }
        }

        public void Play(Color color)
        {
            visualEffect.SetVector4("Color", color);
            visualEffect.Play();
        }
    }
}