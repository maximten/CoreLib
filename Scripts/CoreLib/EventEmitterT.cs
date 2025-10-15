using System;
using System.Collections.Generic;

namespace CoreLib
{
    public static class EventEmitterT<TEnum> where TEnum : Enum
    {
        private static readonly Dictionary<TEnum, Action> _events = new();
        private static readonly Dictionary<TEnum, Action<bool>> _eventsBool = new();
        private static readonly Dictionary<TEnum, Action<int>> _eventsInt = new();
        private static readonly Dictionary<TEnum, Action<float>> _eventsFloat = new();
        private static readonly Dictionary<TEnum, Action<string>> _eventsString = new();
        
        public static void Subscribe(TEnum key, Action action)
        {
            _events[key] += action;
        }

        public static void SubscribeBool(TEnum key, Action<bool> action)
        {
            _eventsBool[key] += action;
        }
        
        public static void SubscribeInt(TEnum key, Action<int> action)
        {
            _eventsInt[key] += action;
        }

        public static void SubscribeFloat(TEnum key, Action<float> action)
        {
            _eventsFloat[key] += action;
        }

        public static void SubscribeString(TEnum key, Action<string> action)
        {
            _eventsString[key] += action;
        }
        
        public static void Unsubscribe(TEnum key, Action action)
        {
            _events[key] -= action;
        }

        public static void UnsubscribeBool(TEnum key, Action<bool> action)
        {
            _eventsBool[key] -= action;
        }
        
        public static void UnsubscribeInt(TEnum key, Action<int> action)
        {
            _eventsInt[key] -= action;
        }

        public static void UnsubscribeFloat(TEnum key, Action<float> action)
        {
            _eventsFloat[key] -= action;
        }

        public static void UnsubscribeString(TEnum key, Action<string> action)
        {
            _eventsString[key] -= action;
        }

        public static void Emit(TEnum key)
        {
            _events[key]?.Invoke();
        }

        public static void EmitBool(TEnum key, bool value)
        {
            _eventsBool[key]?.Invoke(value);
        }

        public static void EmitInt(TEnum key, int value)
        {
            _eventsInt[key]?.Invoke(value);
        }

        public static void EmitFloat(TEnum key, float value)
        {
            _eventsFloat[key]?.Invoke(value);
        }

        public static void EmitString(TEnum key, string value)
        {
            _eventsString[key]?.Invoke(value);
        }
    }
}