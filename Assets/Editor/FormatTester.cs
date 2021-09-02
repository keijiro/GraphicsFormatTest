using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.Rendering;
using System;

static class FormatTester
{
    [MenuItem("Test/Texture Format Test")]
    static void TextureFormatTest()
    {
        foreach (GraphicsFormat format in Enum.GetValues(typeof(GraphicsFormat)))
        {
            if (!SystemInfo.IsFormatSupported(format, FormatUsage.Sample)) continue;

            if (format == GraphicsFormat.DepthAuto  ||
                format == GraphicsFormat.ShadowAuto ||
                format == GraphicsFormat.VideoAuto) continue;

            var tex = new Texture2D(8, 8, format, TextureCreationFlags.None);

            Debug.Log($"{format} texture -> {tex.format}");

            UnityEngine.Object.DestroyImmediate(tex);
        }
    }
}
