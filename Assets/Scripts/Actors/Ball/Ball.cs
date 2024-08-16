using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Test_Pendulum
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D collider2d;
        [SerializeField] private DestroyVFX destroyVfxPrefab;

        public int Id { get; private set; }
        public bool IsInTower { get; private set; }

        public event Action<Ball> OnDestroy;

        private BallConfig config;
        private ScoreService scoreService;
        private ObjectPool<Ball> pool;
        private VFXFactory vfxFactory;

        public void Init(BallConfig config, ScoreService scoreService, ObjectPool<Ball> pool, VFXFactory vfxFactory)
        {
            this.config = config;
            this.scoreService = scoreService;
            this.pool = pool;
            this.vfxFactory = vfxFactory;
            Id = config.Id;
            sprite.color = config.Color;
            IsInTower = false;
        }

        public void SetPosition(Vector3 position) => transform.position = position;
        public void SetInTower(bool isInTower) => IsInTower = isInTower;

        public void EnablePhysics(bool isEnabled)
        {
            collider2d.enabled = isEnabled;
            rb.isKinematic = !isEnabled;
        }

        public void Destroy()
        {
            DestroyVFX vfx = vfxFactory.Create(destroyVfxPrefab, transform.position);
            vfx.Play(config.Color);
            scoreService.AddPoints(config.PointsForDestroy);
            pool.Release(this);
            OnDestroy?.Invoke(this);
        }
    }
}
