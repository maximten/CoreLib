using UnityEngine.UIElements;
using System;
using UnityEngine;

namespace CoreUI
{
    public class SafeWidthContainer : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<SafeWidthContainer, VisualElement.UxmlTraits> {}

        public SafeWidthContainer()
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
                var leftTop = RuntimePanelUtils.ScreenToPanel(panel,
                    new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
                var rightBottom = RuntimePanelUtils.ScreenToPanel(panel,
                    new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));
        
                style.borderLeftWidth= leftTop.x;
                style.borderRightWidth = rightBottom.x;
            }
            catch (InvalidCastException) {}
        }
    }
}
