using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public class StateBehaviorT<KeyT> : MonoBehaviour where KeyT : Enum
    {
        private Dictionary<KeyT, bool> _boolMap = new();
        private Dictionary<KeyT, int> _intMap = new();
        private Dictionary<KeyT, float> _floatMap = new();
        private Dictionary<KeyT, string> _stringMap = new();
        private Dictionary<KeyT, object> _objectMap = new();
        private Dictionary<KeyT, List<Action<bool>>> _boolCallbacks = new();
        private Dictionary<KeyT, List<Action<int>>> _intCallbacks = new();
        private Dictionary<KeyT, List<Action<float>>> _floatCallbacks = new();
        private Dictionary<KeyT, List<Action<string>>> _stringCallbacks = new();
        private Dictionary<KeyT, List<Action<object>>> _objectCallbacks = new();
        
        public void RegisterBool(KeyT key, bool value = false)
        {
            _boolMap.Add(key, value);
        }

        public void SubscribeBool(KeyT key, Action<bool> callback)
        {
            if (!_boolCallbacks.ContainsKey(key))
            {
                _boolCallbacks.Add(key, new List<Action<bool>>());
            }
            _boolCallbacks[key].Add(callback);
        }

        public void UnsubscribeBool(KeyT key, Action<bool> callback)
        {
            _boolCallbacks[key].Remove(callback);
        }

        public bool GetBool(KeyT key)
        {
            if (!_boolMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            return _boolMap[key];
        }

        public void SetBool(KeyT key, bool value)
        {
            if (!_boolMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            _boolMap[key] = value;
            if (!_boolCallbacks.ContainsKey(key))
                return;
            foreach (var action in _boolCallbacks[key])
            {
                action?.Invoke(_boolMap[key]);
            }
        }

        public void RegisterInt(KeyT key, int value = 0)
        {
            _intMap.Add(key, value);
        }

        public void SubscribeInt(KeyT key, Action<int> callback)
        {
            if (!_intCallbacks.ContainsKey(key))
            {
                _intCallbacks.Add(key, new List<Action<int>>());
            }
            _intCallbacks[key].Add(callback);
        }

        public void UnsubscribeInt(KeyT key, Action<int> callback)
        {
            _intCallbacks[key].Remove(callback);
        }

        public int GetInt(KeyT key)
        {
            if (!_intMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            return _intMap[key];
        }

        public void SetInt(KeyT key, int value)
        {
            if (!_intMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            _intMap[key] = value;
            if (!_intCallbacks.ContainsKey(key))
                return;
            foreach (var action in _intCallbacks[key])
            {
                action?.Invoke(_intMap[key]);
            }
        }

        public void RegisterFloat(KeyT key, float value = 0f)
        {
            _floatMap.Add(key, value);
        }

        public void SubscribeFloat(KeyT key, Action<float> callback)
        {
            if (!_floatCallbacks.ContainsKey(key))
            {
                _floatCallbacks.Add(key, new List<Action<float>>());
            }
            _floatCallbacks[key].Add(callback);
        }

        public void UnsubscribeFloat(KeyT key, Action<float> callback)
        {
            _floatCallbacks[key].Remove(callback);
        }

        public float GetFloat(KeyT key)
        {
            if (!_floatMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            return _floatMap[key];
        }

        public void SetFloat(KeyT key, float value)
        {
            if (!_floatMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            _floatMap[key] = value;
            if (!_floatCallbacks.ContainsKey(key))
                return;
            foreach (var action in _floatCallbacks[key])
            {
                action?.Invoke(_floatMap[key]);
            }
        }

        public void RegisterString(KeyT key, string value = "")
        {
            _stringMap.Add(key, value);
        }

        public void SubscribeString(KeyT key, Action<string> callback)
        {
            if (!_stringCallbacks.ContainsKey(key))
            {
                _stringCallbacks.Add(key, new List<Action<string>>());
            }
            _stringCallbacks[key].Add(callback);
        }

        public void UnsubscribeString(KeyT key, Action<string> callback)
        {
            _stringCallbacks[key].Remove(callback);
        }

        public string GetString(KeyT key)
        {
            if (!_stringMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            return _stringMap[key];
        }

        public void SetString(KeyT key, string value)
        {
            if (!_stringMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            _stringMap[key] = value;
            if (!_stringCallbacks.ContainsKey(key))
                return;
            foreach (var action in _stringCallbacks[key])
            {
                action?.Invoke(_stringMap[key]);
            }
        }

        public void RegisterObject(KeyT key, object value = null)
        {
            _objectMap.Add(key, value);
        }

        public void SubscribeObject(KeyT key, Action<object> callback)
        {
            if (!_objectCallbacks.ContainsKey(key))
            {
                _objectCallbacks.Add(key, new List<Action<object>>());
            }
            _objectCallbacks[key].Add(callback);
        }

        public void UnsubscribeObject(KeyT key, Action<object> callback)
        {
            _objectCallbacks[key].Remove(callback);
        }

        public object GetObject(KeyT key)
        {
            if (!_objectMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            return _objectMap[key];
        }

        public void SetObject(KeyT key, object value)
        {
            if (!_objectMap.ContainsKey(key))
            {
                throw new Exception($"Field {key} doesn't exist");
            }
            _objectMap[key] = value;
            if (!_objectCallbacks.ContainsKey(key))
                return;
            foreach (var action in _objectCallbacks[key])
            {
                action?.Invoke(_objectMap[key]);
            }
        }
    }
}