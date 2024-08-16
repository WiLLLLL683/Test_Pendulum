using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Test_Pendulum
{
    [CreateAssetMenu]
    public class BallConfig : ScriptableObject
    {
        public int Id;
        public Color Color;
        public Sprite Sprite;
        public AudioClip[] DestroySounds;
        public int PointsForDestroy;

        public AudioClip GetRandomDestroySound()
        {
            return DestroySounds[UnityEngine.Random.Range(0, DestroySounds.Length)];
        }
    }
}