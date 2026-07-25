using UnityEngine;

public class ToggleTrigger : Trigger
{
    [SerializeField] private string groupName;
    [SerializeField] private bool targetState;
    public override void Activate()
    {
        GameObject[] objects = GetObjectsFromGroup(groupName);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(targetState);
        }

        //Debug.Log("Toggled " + groupName + " to " + targetState);
    }
}
