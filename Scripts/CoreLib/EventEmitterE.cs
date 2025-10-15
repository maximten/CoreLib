using System;
using System.Collections.Generic;

namespace CoreLib
{
    public static class EventEmitterE<TAction, TEnum> where TAction : Enum where TEnum : Enum
    {
        private static readonly Dictionary<TAction, List<Action<TEnum>>> _events = new();
        
        public static void Subscribe(TAction key, Action<TEnum> action)
        {
            if (!_events.ContainsKey(key))
                _events.Add(key, new ());
            _events[key].Add(action);
        }
        
        public static void Unsubscribe(TAction key, Action<TEnum> action)
        {
            _events[key].Remove(action);
        }
        
        public static void Emit(TAction key, TEnum value)
        {
            foreach (var action in _events[key])
            {
                action?.Invoke(value);
            }
        }
    }
}