using UnityEditor;
using UnityEngine;

namespace PubScale.SdkOne
{
    using System.IO;

    [InitializeOnLoad]
    public static class OpenWindowsOnLoad
    {
        static OpenWindowsOnLoad()
        {
            if (!Directory.Exists(PubEditorUX.PackageSettingsPath))
            {
                Directory.CreateDirectory(PubEditorUX.PackageSettingsFolderPath);
            }
            PubScaleSettings settings = AssetDatabase.LoadAssetAtPath<PubScaleSettings>(PubEditorUX.PackageSettingsPath);

            if (settings == null)
            {
                settings = PubEditorUX.CreateAndSavePubScaleSettings();
            }

            if (settings != null && settings.IsFirstTimeUsingTheAsset)
            {
                EditorApplication.delayCall += PubScaleWindow.OpenWindow;
            }

        }
    }
}
