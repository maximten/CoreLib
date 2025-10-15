using System;
using System.Collections.Generic;

namespace CoreLib
{
    public static class EventEmitterT<TEnum> where TEnum : Enum
    {
        private static readonly Dictionary<TEnum, List<Action>> _events = new();
        private static readonly Dictionary<TEnum, List<Action<bool>>> _eventsBool = new();
        private static readonly Dictionary<TEnum, List<Action<int>>> _eventsInt = new();
        private static readonly Dictionary<TEnum, List<Action<float>>> _eventsFloat = new();
        private static readonly Dictionary<TEnum, List<Action<string>>> _eventsString = new();
        
        public static void Subscribe(TEnum key, Action action)
        {
            if (!_events.ContainsKey(key))
                _events.Add(key, new ());
            _events[key].Add(action);
        }

        public static void SubscribeBool(TEnum key, Action<bool> action)
        {
            if (!_eventsBool.ContainsKey(key))
                _eventsBool.Add(key, new());
            _eventsBool[key].Add(action);
        }
        
        public static void SubscribeInt(TEnum key, Action<int> action)
        {
            if (!_eventsInt.ContainsKey(key))
                _eventsInt.Add(key, new());
            _eventsInt[key].Add(action);
        }

        public static void SubscribeFloat(TEnum key, Action<float> action)
        {
            if (!_eventsFloat.ContainsKey(key))
                _eventsFloat.Add(key, new());
            _eventsFloat[key].Add(action);
        }

        public static void SubscribeString(TEnum key, Action<string> action)
        {
            if (!_eventsString.ContainsKey(key))
                _eventsString.Add(key, new());
            _eventsString[key].Add(action);
        }
        
        public static void Unsubscribe(TEnum key, Action action)
        {
            _events[key].Remove(action);
        }

        public static void UnsubscribeBool(TEnum key, Action<bool> action)
        {
            _eventsBool[key].Remove(action);
        }
        
        public static void UnsubscribeInt(TEnum key, Action<int> action)
        {
            _eventsInt[key].Remove(action);
        }

        public static void UnsubscribeFloat(TEnum key, Action<float> action)
        {
            _eventsFloat[key].Remove(action);
        }

        public static void UnsubscribeString(TEnum key, Action<string> action)
        {
            _eventsString[key].Remove(action);
        }

        public static void Emit(TEnum key)
        {
            foreach (var action in _events[key])
                action?.Invoke();
        }

        public static void EmitBool(TEnum key, bool value)
        {
            foreach (var action in _eventsBool[key])
                action?.Invoke(value);
        }

        public static void EmitInt(TEnum key, int value)
        {
            foreach (var action in _eventsInt[key])
                action?.Invoke(value);
        }

        public static void EmitFloat(TEnum key, float value)
        {
            foreach (var action in _eventsFloat[key])
                action?.Invoke(value);
        }

        public static void EmitString(TEnum key, string value)
        {
            foreach (var action in _eventsString[key])
                action?.Invoke(value);
        }
    }
}