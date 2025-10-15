using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core
{
    public static class AddressableLoaderT<KeyT>  where KeyT : Enum
    {
        private static Dictionary<KeyT, GameObject> _prefabMap = new();
        
        public static IEnumerator Load(KeyT key)
        {
            if (_prefabMap.ContainsKey(key))
                yield break;
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(key.ToString());
            yield return handle;
            _prefabMap.Add(key, handle.Result);
            handle.Release();
        }

        public static GameObject Get(KeyT key)
        {
            return _prefabMap[key];
        }
    }
}