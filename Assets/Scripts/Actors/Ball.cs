using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private BallConfig config;

        public void Init(BallConfig config)
        {
            this.config = config;
            Id = config.Id;
            sprite.color = config.Color;
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
            DestroyVFX vfx = Instantiate(destroyVfxPrefab, transform.position, Quaternion.identity);
            vfx.Play(config.Color);
            Destroy(gameObject);
        }
    }
}
