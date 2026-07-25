using System.Collections;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField] private string groupName;
    void Start()
    {
        StartCoroutine(WaitForManager());
    }
    IEnumerator WaitForManager()
    {
        yield return new WaitForEndOfFrame();
        GroupManager.instance.AddGroup(groupName, gameObject);
    }
}
