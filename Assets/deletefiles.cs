using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class deletefiles : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Assets/ReformTexture/deleteGuide", priority = 2, validate = false)]
    static void DelGuide()
    {
        string g = "guide";
        string g1 = "Guide";
        var selectedAssets = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);
        foreach(var asset in selectedAssets)
        {
            bool check = asset.name.Contains(g) || asset.name.Contains(g1);

            if (check)
            {
                string assetPath = AssetDatabase.GetAssetPath(asset);
                File.Delete(assetPath);
            }
        }
    }
#endif
}
