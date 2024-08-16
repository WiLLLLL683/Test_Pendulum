using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Test_Pendulum
{
    public class VFXFactory
    {
        private readonly ObjectPool<DestroyVFX> pool;

        private DestroyVFX prefab;
        private Vector3 position;

        public VFXFactory()
        {
            pool = new(Instantiate, Get, Release, Destroy, true, 100, 1000);
        }

        public DestroyVFX Create(DestroyVFX prefab, Vector3 position)
        {
            this.prefab = prefab;
            this.position = position;

            return pool.Get();
        }

        private DestroyVFX Instantiate()
        {
            return UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
        }

        private void Get(DestroyVFX vfx)
        {
            if (vfx == null)
                return;

            vfx.gameObject.SetActive(true);
            vfx.transform.position = position;
            vfx.Init(pool);
        }

        private void Release(DestroyVFX vfx)
        {
            vfx.gameObject.SetActive(false);
        }

        private void Destroy(DestroyVFX vfx)
        {
            UnityEngine.Object.Destroy(vfx.gameObject);
        }
    }
}