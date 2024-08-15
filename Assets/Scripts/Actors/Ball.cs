using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class Ball : MonoBehaviour
    {
        public int Id { get; private set; }

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject destroyVfxPrefab;

        private void Init()
        {

        }

        public void SetPosition(Vector3 position) => transform.position = position;
        public void EnablePhysics(bool isEnabled) => rb.isKinematic = !isEnabled;

        public void Destroy()
        {
            Instantiate(destroyVfxPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
