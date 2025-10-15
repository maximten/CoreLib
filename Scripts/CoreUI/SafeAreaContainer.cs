using UnityEngine.UIElements;
using System;
using UnityEngine;

namespace CoreUI
{
    public class SafeAreaContainer : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<SafeAreaContainer, VisualElement.UxmlTraits> {}

        private Vector2 _leftTop = Vector2.zero;
        private Vector2 _rightBottom = Vector2.zero;

        public SafeAreaContainer()
        {
            AddToClassList("safeArea");
            style.flexGrow = 1;
            style.flexShrink = 1;
            RegisterCallback<GeometryChangedEvent>(LayoutChanged);
        }

        private void LayoutChanged(GeometryChangedEvent e)
        {
            var safeArea = Screen.safeArea;

            try
            {
                _leftTop = RuntimePanelUtils.ScreenToPanel(panel,
                    new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
                _rightBottom = RuntimePanelUtils.ScreenToPanel(panel,
                    new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));
        
                style.borderLeftWidth= _leftTop.x;
                style.borderTopWidth = _leftTop.y;
                style.borderRightWidth = _rightBottom.x;
                style.borderBottomWidth = _rightBottom.y;
            }
            catch (InvalidCastException) {}
        }
    }
}
