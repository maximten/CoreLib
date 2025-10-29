using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public static class MyMath
    {
        public static int Mod(int a, int b)
        {
            return ((a % b) + b) % b;
        }
        
        public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        }

        public static float GetMinDist(Vector3 target, List<Vector3> list)
        {
            float result = float.MaxValue;
            foreach (var vector3 in list)
            {
                var dist = Vector3.Distance(vector3, target);
                result = Mathf.Min(dist, result);
            }
            return result;
        }
        
        public static float EaseOutBack(float t, float s = 2.5f)
        {
            t -= 1f;
            return t * t * ((s + 1) * t + s) + 1f;
        }
    }
}