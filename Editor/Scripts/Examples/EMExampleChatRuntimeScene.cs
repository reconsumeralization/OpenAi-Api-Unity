﻿using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class ExampleChatRuntimeScene
{
    private const string cSceneName = "ExampleChatRuntimeScene";

    [MenuItem("OpenAi/Examples/Chat at Runtime")]
    public static void OpenScene()
    {
        string[] assets = AssetDatabase.FindAssets(cSceneName);

        string path = null;
        foreach (string guid in assets)
        {
            path = AssetDatabase.GUIDToAssetPath(guid);
        }

        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError($"Cannot find the scene: {cSceneName}");
            return;
        }

        string newScenePath = $"Assets/{cSceneName}.unity";
        AssetDatabase.CopyAsset(path, newScenePath);
        EditorSceneManager.OpenScene(newScenePath);

        AssetDatabase.Refresh();
        Selection.activeObject = AssetDatabase.LoadAssetAtPath(newScenePath, typeof(Object));
    }
}
