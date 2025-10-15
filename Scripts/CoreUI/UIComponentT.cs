using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreUI
{
    public class UIComponentT<KeyT> : MonoBehaviour where KeyT : Enum
    {
        [SerializeField] public KeyT UIName;
        [SerializeField] protected UIDocument document;

        protected Action _afterEnable;
        protected Action _beforeDisable;
        
        private void OnEnable()
        {
            _afterEnable?.Invoke();
        }

        private void OnDisable()
        {
            _beforeDisable?.Invoke();
        }

        protected void Toggle(VisualElement el, bool shouldShow)
        {
            el.style.display = shouldShow ? DisplayStyle.Flex : DisplayStyle.None;
        }

        protected void VisibilityToggle(VisualElement el, bool shouldShow)
        {
            el.style.visibility = shouldShow ? Visibility.Visible : Visibility.Hidden;
        }

        protected void OnClick(string elName, Action onClick)
        {
            var button = document.rootVisualElement.Q<Button>(elName);
            button.clicked += onClick;
        }

        protected void OnClickInstant(string elName, EventCallback<PointerDownEvent> onClick)
        {
            var button = document.rootVisualElement.Q<Button>(elName);
            button.clickable = null;
            button.RegisterCallback(onClick);
        }
    }
}