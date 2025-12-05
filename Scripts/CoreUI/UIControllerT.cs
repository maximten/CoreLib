using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreUI 
{
    public class UIControllerT<KeyT> : MonoBehaviour where  KeyT : Enum
    {
        public static UIControllerT<KeyT> Current;

        protected Dictionary<KeyT, UIComponentT<KeyT>> _map = new();
        protected List<UIComponentT<KeyT>> _enabledList = new();
        protected Stack<UIComponentT<KeyT>> _stack = new();

        protected void Awake()
        {
            Current = this;
            
            var componentList =  GetComponentsInChildren<UIComponentT<KeyT>>(true).ToList();
            foreach (var component in componentList)
            {
                _map.Add(component.UIName, component);
                // component.gameObject.SetActive(false);
            }
        }
        
        public void Clear()
        {
            foreach (var component in _enabledList)
            {
                component.gameObject.SetActive(false);
            }
            _enabledList.Clear();
        }
        
        public void Render(KeyT ui)
        {
            Clear();
            _stack.Clear();
            var component = _map[ui];
            component.gameObject.SetActive(true);
            _enabledList.Add(component);
            _stack.Push(component);
        }
        
        public void Push(KeyT ui)
        {
            Clear();
            var component = _map[ui];
            component.gameObject.SetActive(true);
            _enabledList.Add(component);
            _stack.Push(component);
        }

        public void Pop()
        {
            Clear();
            _stack.Pop();
            var component = _stack.Peek();
            component.gameObject.SetActive(true);
            _enabledList.Add(component);
        }
    }
}