using System;
using UnityEngine;
using UnityEngine.Pool;

namespace CoreLib
{
    public class ObjectPoolBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject Prefab;
        private ObjectPool<GameObject> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(
                () =>
                {
                    var obj = Instantiate(Prefab);
                    obj.SetActive(false);
                    return obj;
                },
                (GameObject obj) =>
                {
                    obj.SetActive(true);
                },
                (GameObject obj) =>
                {
                    obj.SetActive(false);
                },
                (GameObject obj) =>
                {
                    if (obj != null)
                        Destroy(obj);
                }
            );
        }
    }
}