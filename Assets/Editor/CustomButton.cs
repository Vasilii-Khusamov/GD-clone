using System;
using LevelManager;
using Temp;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
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
            if (GUILayout.Button("Save level"))
            {
                UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
                string levelString = LevelSerializer.SerializeLevel(scene);
                string levelFolder = Application.dataPath + "/Levels";
                string levelName = scene.name;
                Debug.Log("Level name is " + levelName);
                Debug.Log(levelFolder);
                Debug.Log(levelString);

                FileUtils.CreateOrOverwriteFile(levelFolder, levelName + ".txt", levelString);
            }
        }
 
    }
}
