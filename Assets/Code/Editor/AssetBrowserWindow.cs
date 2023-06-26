using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBrowserWindow : EditorWindow
{
    private Object currentAsset;
    public Object source;

    [MenuItem("Tools/Asset Browser")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        AssetBrowserWindow window = (AssetBrowserWindow)GetWindow(typeof(AssetBrowserWindow));
        window.Show();
    }

    void OnGUI()
    {

        EditorGUILayout.HelpBox("Browse game assets and edit them from here! " +
            "You can use standard filtering like 't:WeaponData'.", MessageType.Info);
        EditorGUILayout.BeginHorizontal();
        currentAsset = EditorGUILayout.ObjectField("Current Asset", currentAsset, typeof(GameAsset), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        if (currentAsset == null)
            return;

        Editor editor = Editor.CreateEditor(currentAsset);
        editor.CreateInspectorGUI();
        editor.OnInspectorGUI();
    }
}