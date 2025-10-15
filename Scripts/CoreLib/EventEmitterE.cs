using System;
using System.Collections.Generic;

namespace CoreLib
{
    public static class EventEmitterE<TAction, TEnum> where TAction : Enum where TEnum : Enum
    {
        private static readonly Dictionary<TAction, Action<TEnum>> _events = new();
        
        public static void Subscribe(TAction key, Action<TEnum> action)
        {
            _events[key] += action;
        }
        
        public static void Unsubscribe(TAction key, Action<TEnum> action)
        {
            _events[key] -= action;
        }
        
        public static void Emit(TAction key, TEnum value)
        {
            _events[key]?.Invoke(value);
        }
    }
}