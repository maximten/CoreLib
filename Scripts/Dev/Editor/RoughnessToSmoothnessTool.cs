using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dev
{
    public static class RoughnessToSmoothnessTool
    {
        [MenuItem("CoreTools/Convert to Smoothness", true)]
        private static bool ValidateConvert() =>
            Selection.activeObject is Texture2D;

        [MenuItem("CoreTools/Convert to Smoothness")]
        private static void ConvertSelected()
        {
            var tex = Selection.activeObject as Texture2D;
            if (tex == null)
            {
                Debug.LogError("Please select a roughness texture.");
                return;
            }

            string path = AssetDatabase.GetAssetPath(tex);
            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string outPath = Path.Combine(dir, name + "_Smoothness.png");

            // ensure readable and linear
            var importer = (TextureImporter)AssetImporter.GetAtPath(path);
            bool prevReadable = importer.isReadable;
            bool prevSRGB = importer.sRGBTexture;
            importer.isReadable = true;
            importer.sRGBTexture = false;
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            Texture2D src = tex;
            Texture2D dst = new Texture2D(src.width, src.height, TextureFormat.RGBA32, false, true);

            Color[] pixels = src.GetPixels();
            for (int i = 0; i < pixels.Length; i++)
            {
                float rough = pixels[i].r;        // assume grayscale roughness in R
                float smooth = 1f - rough;        // invert
                pixels[i] = new Color(smooth, smooth, smooth, 1f);
            }
            dst.SetPixels(pixels);
            dst.Apply();

            File.WriteAllBytes(outPath, dst.EncodeToPNG());
            AssetDatabase.Refresh();

            // restore importer
            importer.isReadable = prevReadable;
            importer.sRGBTexture = prevSRGB;
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            Debug.Log($"✅ Created smoothness texture: {outPath}");
        }
    }
}