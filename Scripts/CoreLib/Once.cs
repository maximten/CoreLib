using System;

namespace CoreLib
{
    public class Once
    {
        public Action Callback;
        public bool _ran = false;

        public Once(Action callback)
        {
            Callback = callback;
        }

        public void Run()
        {
            if (_ran)
                return;
            _ran = true;
            Callback?.Invoke();
        }

        public Action DoOnce()
        {
            return Run;
        }
    }
}