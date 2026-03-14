using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public AudioClip music;
}
