using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GroupManager : MonoBehaviour
{
    private Dictionary<string, GameObject[]> groups = new Dictionary<string, GameObject[]>();
    
    public static GroupManager instance = null;
    
    private int counter = 0;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void Update()
    {
        counter++;
        if (counter == 3)
        {
            foreach (var group in groups)
            {
                //Debug.Log(group.Key + ": " + group.Value.Length);
            }

        }
    }

    public void AddGroup(string group, GameObject obj)
    {
        if (!groups.ContainsKey(group))
        {
            groups.Add(group, new GameObject[] { obj });
        }
        else
        {
            groups[group] = groups[group].Append(obj).ToArray();
        }
    }
    public GameObject[] GetGroup(string group)
    {
        if (groups.ContainsKey(group))
        {
            return groups[group];
        }
        else
        {
            return null;
        }
    }
}
