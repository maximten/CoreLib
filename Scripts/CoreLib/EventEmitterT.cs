using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public static class EventEmitterT<TEnum> where TEnum : Enum
    {
        private static readonly Dictionary<(TEnum, Type), List<Delegate>> _events = new();

        // Subscribe to an event of type T
        public static void Subscribe<T>(TEnum key, Action<T> action)
        {
            var tuple = (key, typeof(T));
            if (!_events.ContainsKey(tuple))
                _events.Add(tuple, new());
            _events[tuple].Add(action);
        }

        // Subscribe to parameterless event
        public static void Subscribe(TEnum key, Action action)
        {
            var tuple = (key, typeof(void));
            if (!_events.ContainsKey(tuple))
                _events.Add(tuple, new());
            _events[tuple].Add(action);
        }

        // Unsubscribe typed
        public static void Unsubscribe<T>(TEnum key, Action<T> action)
        {
            var tuple = (key, typeof(T));
            if (_events.TryGetValue(tuple, out var list))
                list.Remove(action);
        }

        // Unsubscribe parameterless
        public static void Unsubscribe(TEnum key, Action action)
        {
            var tuple = (key, typeof(void));
            if (_events.TryGetValue(tuple, out var list))
                list.Remove(action);
        }

        // Emit typed event
        public static void Emit<T>(TEnum key, T value)
        {
            var tuple = (key, typeof(T));
            if (_events.TryGetValue(tuple, out var list))
            {
                foreach (var del in list)
                    (del as Action<T>)?.Invoke(value);
            }
        }

        // Emit parameterless
        public static void Emit(TEnum key)
        {
            var tuple = (key, typeof(void));
            if (_events.TryGetValue(tuple, out var list))
            {
                foreach (var del in list)
                    (del as Action)?.Invoke();
            }
        }

        // Optional cleanup method
        public static void ClearAll()
        {
            _events.Clear();
        }
    }
}
