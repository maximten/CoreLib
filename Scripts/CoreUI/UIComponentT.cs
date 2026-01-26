using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CoreUI
{
    public class UIComponentT<KeyT> : MonoBehaviour where KeyT : Enum
    {
        public KeyT UIName;
        protected UIDocument _document;

        protected void Awake()
        {
            _document = GetComponent<UIDocument>();
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
            var button = _document.rootVisualElement.Q<Button>(elName);
            button.clicked += onClick;
        }

        protected void OnClickInstant(string elName, EventCallback<PointerDownEvent> onClick)
        {
            var button = _document.rootVisualElement.Q<Button>(elName);
            button.clickable = null;
            button.RegisterCallback(onClick);
        }

        protected T Find<T>(string elName) where T : VisualElement
        {
            return _document.rootVisualElement.Q<T>(elName);
        }

        public UIDocument GetDocument()
        {
            return _document;
        }

        protected void SetText(string elName, string text)
        {
            Find<TextElement>(elName).text = text;
        }
    }
}