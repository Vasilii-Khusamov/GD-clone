using System;
using LevelManager;
using Temp;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(OpenFileButtonScript))]
    public class CustomButton : UnityEditor.Editor
    {
 
        
        public override void OnInspectorGUI()
        // Код взят отсюда https://stackoverflow.com/questions/37232573/add-button-to-unity3d-editor
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Change level folder"))
            {
                OpenFileButtonScript myScript = (OpenFileButtonScript)target;
                myScript.ChangeLevelFolder();
            }
            if (GUILayout.Button("Serialize level"))
            {
                Debug.Log(LevelSerializer.SerializeLevel(SceneManager.GetActiveScene()));
            }
        }
 
    }
}
