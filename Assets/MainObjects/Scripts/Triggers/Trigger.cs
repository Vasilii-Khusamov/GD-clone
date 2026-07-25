using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public abstract void Activate();
    protected GameObject[] GetObjectsFromGroup(string groupName)
    {
        GroupManager groupManager = GroupManager.instance;

        if (groupManager == null)
        {
            Debug.LogError("GroupManager instance not found!");
            return new GameObject[0];
        }

        return groupManager.GetGroup(groupName);
    }
}
