using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public class Jobs : MonoBehaviour
    {
        public struct Job
        {
            public bool IsAction;
            public Action callback;
            public IEnumerator coroutine;
        };
        
        private static Queue<Job> _queue = new();

        public static void Add(Action job)
        {
            _queue.Enqueue(new Job(){IsAction = true, callback = job});
        }

        public static void Add(IEnumerator coroutine)
        {
            _queue.Enqueue(new Job(){IsAction = false, coroutine = coroutine});
        }

        private void OnEnable()
        {
            StartCoroutine(DoJobs());
        }

        IEnumerator DoJobs()
        {
            while (true)
            {
                yield return null;
                if (_queue.Count == 0)
                    continue;
                var job = _queue.Dequeue();
                if (job.IsAction)
                {
                    job.callback?.Invoke();
                }
                else
                {
                    yield return job.coroutine;
                }
            }
        }
    }
}