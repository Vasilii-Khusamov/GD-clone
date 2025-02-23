#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;



namespace Temp
{
    public class OpenFileButtonScript : MonoBehaviour
    {
        public string levelFolder = "Куку, тут директория должна быть";

        public void ChangeLevelFolder()
        {
            levelFolder = (
                EditorUtility.OpenFolderPanel(
                    "Select level folder", 
                    "", 
                    "Levels"
                )
            );
        }
    }
}
#endif