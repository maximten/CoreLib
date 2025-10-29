using System;
using Newtonsoft.Json;
using UnityEngine;

namespace CoreLib
{
    public static class PersistenceT<StoreT> where StoreT : Enum
    {
		public static void SaveInt(StoreT key, int val)
		{
            PlayerPrefs.SetInt(key.ToString(), val);
            PlayerPrefs.Save();
		}

		public static int LoadInt(StoreT key, int defaultVal)
		{
            var res = PlayerPrefs.GetInt(key.ToString(), defaultVal);
            return res;
		}

		public static void SaveString(StoreT key, string val)
		{
            PlayerPrefs.SetString(key.ToString(), val);
            PlayerPrefs.Save();
		}

		public static string LoadString(StoreT key, string defaultVal)
		{
            var res = PlayerPrefs.GetString(key.ToString(), defaultVal);
            return res;
		}

		public static void SaveBool(StoreT key, bool val)
		{
            PlayerPrefs.SetInt(key.ToString(), val ? 1 : 0);
            PlayerPrefs.Save();
		}

		public static bool LoadBool(StoreT key, bool defaultVal)
		{
            return PlayerPrefs.GetInt(key.ToString(), defaultVal ? 1 : 0) > 0;
		}

		public static void SaveObj<T>(StoreT key, T val)
		{
            PlayerPrefs.SetString(key.ToString(), JsonConvert.SerializeObject(val));
            PlayerPrefs.Save();
		}

		public static T LoadObj<T>(StoreT key)
		{
            var value = PlayerPrefs.GetString(key.ToString());
            return JsonConvert.DeserializeObject<T>(value);
		}
    }
}