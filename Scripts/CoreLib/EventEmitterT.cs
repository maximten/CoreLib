using System;
using System.Collections.Generic;

namespace CoreLib
{
    public static class EventEmitterT<TEnum> where TEnum : Enum
    {
        private static readonly Dictionary<TEnum, Action> _events = new();
        
        public static void Subscribe(TEnum key, Action action)
        {
            _events[key] += action;
        }
        
        public static void Unsubscribe(TEnum key, Action action)
        {
            _events[key] -= action;
        }
        
        public static void Emit(TEnum key)
        {
            _events[key]?.Invoke();
        }
    }
}