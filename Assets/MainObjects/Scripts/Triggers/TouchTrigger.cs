using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    [SerializeField] private string triggerGroup;
    // tag that trigger whould respond to.
    [SerializeField] private string targetTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            GameObject[] triggers = GroupManager.instance.GetGroup(triggerGroup);
            foreach (GameObject trigger in triggers)
            {
                trigger.GetComponent<Trigger>()?.Activate();
            }

            //Debug.Log("Activated " + triggerGroup);
        }
    }
}
