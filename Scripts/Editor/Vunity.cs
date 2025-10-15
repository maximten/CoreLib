using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class Vunity
    {
        [MenuItem("Window/Focus/Hierarchy &1")] // Alt + 1
        public static void FocusHierarchy()
        {
            var window = GetWindowOfType("UnityEditor.SceneHierarchyWindow");
            window?.Focus();
        }

        [MenuItem("Window/Focus/Project &2")] // Alt + 2
        public static void FocusProject()
        {
            var window = GetWindowOfType("UnityEditor.ProjectBrowser");
            window?.Focus();
        }

        [MenuItem("Window/Focus/Inspector &3")] // Alt + 3
        public static void FocusInspector()
        {
            var window = GetWindowOfType("UnityEditor.InspectorWindow");
            window?.Focus();
        }
        
        [MenuItem("Window/Focus/Scene &4")] // Alt + 4
        public static void FocusScene()
        {
            var window = GetWindowOfType("UnityEditor.SceneView");
            window?.Focus();
        }
        
        [MenuItem("Window/Focus/Console &5")] // Alt + 5
        public static void FocusConsole()
        {
            var window = GetWindowOfType("UnityEditor.ConsoleWindow");
            window?.Focus();
        }

        private static EditorWindow GetWindowOfType(string typeName)
        {
            var type = typeof(UnityEditor.Editor).Assembly.GetType(typeName);
            if (type == null)
            {
                Debug.LogError($"Cannot find type: {typeName}");
                return null;
            }

            return EditorWindow.GetWindow(type);
        }
    }
}
