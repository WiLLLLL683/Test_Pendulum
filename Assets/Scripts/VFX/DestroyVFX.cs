using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.VFX;

namespace Test_Pendulum
{
    public class DestroyVFX : MonoBehaviour
    {
        [SerializeField] private VisualEffect visualEffect;

        private bool hasPlayed;

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
                Destroy(gameObject);
            }
        }

        public void Play(Color color)
        {
            visualEffect.SetVector4("Color", color);
            visualEffect.Play();
        }
    }
}