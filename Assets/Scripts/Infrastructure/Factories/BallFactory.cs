using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Test_Pendulum
{
    public class BallFactory
    {
        private readonly ConfigProvider configProvider;
        private readonly ScoreService scoreService;
        private readonly AudioService audioService;
        private readonly VFXFactory vfxFactory;
        private readonly ObjectPool<Ball> pool;

        private Ball prefab;
        private Vector3 position;
        private BallConfig config;
        private bool hasPhysics;

        public BallFactory(ConfigProvider configProvider, ScoreService scoreService, AudioService audioService, VFXFactory vfxFactory)
        {
            this.configProvider = configProvider;
            this.scoreService = scoreService;
            this.audioService = audioService;
            this.vfxFactory = vfxFactory;
            pool = new(Instantiate, Get, Release, Destroy, true, 100, 1000);
        }

        public Ball CreateRandom(Ball prefab, Vector3 position, bool hasPhysics = true) =>
            Create(prefab, position, configProvider.GetRandomBallConfig(), hasPhysics);

        public Ball Create(Ball prefab, Vector3 position, BallConfig config, bool hasPhysics = true)
        {
            this.hasPhysics = hasPhysics;
            this.config = config;
            this.position = position;
            this.prefab = prefab;

            return pool.Get();
        }

        private Ball Instantiate()
        {
            return GameObject.Instantiate(prefab, position, Quaternion.identity);
        }

        private void Get(Ball ball)
        {
            if (ball == null)
                return;

            ball.gameObject.SetActive(true);
            ball.transform.position = position;
            ball.Init(config, scoreService, audioService, pool, vfxFactory);
            ball.EnablePhysics(hasPhysics);
        }

        private void Release(Ball ball)
        {
            ball.gameObject.SetActive(false);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        private void Destroy(Ball ball)
        {
            GameObject.Destroy(ball.gameObject);
        }
    }
}