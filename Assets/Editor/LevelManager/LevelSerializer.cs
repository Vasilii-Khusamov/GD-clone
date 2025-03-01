using LevelManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LevelSerializer : MonoBehaviour
{
    public static string SerializeLevel(Scene scene)
    {
        string levelString = "";


        ObjectSerializer objectSerializer = new ObjectSerializer();
        foreach (var gameObject in scene.GetRootGameObjects())
        {
            if (gameObject.CompareTag("EditorOnly")) continue;
            if (gameObject.GetPrefabDefinition() is null)
            {
                Debug.LogWarning("Objects without prefab definition will not be saved.", gameObject);
                continue;
            } 
                    
            string serializedObject = objectSerializer.SerializeObject(gameObject);
            levelString += serializedObject + "\n";
        }

        return levelString;
    }
}
