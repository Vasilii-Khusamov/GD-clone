using System;
using System.Linq;
using UnityEngine;

public class DisableHero : MonoBehaviour
{
    private readonly Type[] _componentDisableWhiteList =
    {
        typeof(Transform),
        typeof(SpriteRenderer)
    };


    public void Disable()
    {
        Component[] heroComponents = gameObject.GetComponents<Component>();
        foreach (Component currentComponent in heroComponents)
        {
            if (!_componentDisableWhiteList.Contains(currentComponent.GetType()))
            { 
                Destroy(currentComponent);
            }
        }
    }
}
