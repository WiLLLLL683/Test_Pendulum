using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;

namespace Test_Pendulum
{
    public class Ball : MonoBehaviour
    {
        public int Id { get; private set; }
        public bool IsInTower { get; private set; }

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D collider2d;
        [SerializeField] private DestroyVFX destroyVfxPrefab;

        public void Init()
        {

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
            vfx.Play(Color.green); //TODO config
            Destroy(gameObject);
        }
    }
}
