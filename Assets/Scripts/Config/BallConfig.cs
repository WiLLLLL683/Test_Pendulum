﻿using System;
using UnityEngine;

namespace Test_Pendulum
{
    [CreateAssetMenu]
    public class BallConfig : ScriptableObject
    {
        public int Id;
        public Color Color;
        public Sprite Sprite;
        public int PointsForDestroy;
    }
}