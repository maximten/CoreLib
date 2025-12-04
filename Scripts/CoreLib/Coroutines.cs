using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public static class Coroutines
    {
        public static IEnumerator WithDelay(Action callback, float delay)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        public static IEnumerator AfterFrame(Action callback)
        {
            yield return new WaitForEndOfFrame();
            callback?.Invoke();
        }
		
        public static IEnumerator AfterUpdate(Action callback)
        {
            yield return new WaitForFixedUpdate();
            callback?.Invoke();
        }
		
        public static IEnumerator After(Func<bool> condition, Action callback)
        {
            yield return new WaitUntil(condition);
            callback?.Invoke();
        }

        public static IEnumerator AfterFrames(List<Action> callbacks)
        {
            foreach (var callback in callbacks)
            {
                yield return new WaitForEndOfFrame();
                callback?.Invoke();
            }
        }

        public static IEnumerator TimerAction(Action<float> action, float time, float step = 0, Action finalAction = null)
        {
            var c = time;
            while (c >= 0)
            {
                var t = 1 - c / time;
                action(t);
                c -= step == 0 ? Time.deltaTime : step;
                if (step == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return new WaitForSeconds(step);
                }
            }
            if (finalAction != null)
            {
                finalAction?.Invoke();
            }
        }

        public static IEnumerator CounterAction(Action<int> action, Action finalAction, int count, float step = 0)
        {
            var c = count;
            while (c >= 0)
            {
                action(c);
                c--;
                if (step == 0)
                {
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    yield return new WaitForSeconds(step);
                }
            }
            finalAction?.Invoke();
        }

        public static IEnumerator TransformLerp(
            GameObject target,
            Transform from,
            Transform to,
            float time,
            float step = 0)
        {
            target.transform.position = from.position;
            target.transform.rotation = from.rotation;
            yield return TimerAction(t =>
            {
                target.transform.position = Vector3.Lerp(from.position, to.position, t);
                target.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, t);
            }, time, step);
            target.transform.position = to.position;
            target.transform.rotation = to.rotation;
        }
    }
}