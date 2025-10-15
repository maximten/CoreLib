using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public static class RegistryT<KeyT> where KeyT: Enum
    {
        public static Dictionary<KeyT, Dictionary<int, GameObject>> Map = new();
        
        public static void Add(KeyT key, GameObject obj)
        {
            if (!Map.ContainsKey(key))
            {
                Map.Add(key, new ());
            }
            if (Map[key].ContainsKey(obj.GetInstanceID()))
            {
                Map[key][obj.GetInstanceID()] = obj;
                return;
            }
            Map[key].Add(obj.GetInstanceID(), obj);
        }

        public static void Remove(KeyT key, GameObject obj)
        {
            Map[key].Remove(obj.GetInstanceID());
        }
    }
}