using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoreLib
{
    public static class Timestamp
    {
        private static Dictionary<string, float> _timerDict = new Dictionary<string, float>();
        private static float _time;
        private static bool _hasStart;
        
        public static int Get()
        {
            return (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static string GetDateString()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd");
        }

        public static DateTime ParseDateString(string val)
        {
            return DateTime.ParseExact(val, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static void MarkStart()
        {
            _time = UnityEngine.Time.time;
        }

        public static void MarkStart(string key)
        {
            if (!_timerDict.ContainsKey(key))
            {
                _timerDict.Add(key, 0);
            }
            _timerDict[key] = UnityEngine.Time.time;
        }

        public static float MarkEnd()
        {
            return UnityEngine.Time.time - _time;
        }

        public static float MarkEnd(string key)
        {
            if (!_timerDict.ContainsKey(key))
                return 0;
            return UnityEngine.Time.time - _timerDict[key];
        }
        
        public static (bool, float) Mark()
        {
            if (!_hasStart)
            {
                _time = UnityEngine.Time.time;
                _hasStart = true;
                return (false, 0);
            }
            var diff = UnityEngine.Time.time - _time;
            _hasStart = false;
            return (true, diff);
        }
    }
}