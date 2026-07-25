using System.Collections;
using UnityEngine;

public class TransformTrigger : Trigger
{
    //[SerializeField] Transform targetTransform; // offset.
    [SerializeField] private string groupName; // group of objects to transform.
    [SerializeField] private Vector3 offset;
    [SerializeField] float durationSeconds = 1f; // duration of the transformation.

    // interpolation curve for the transformation.
    [SerializeField] AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);

    public override void Activate()
    {
        GameObject[] gameObjects = GetObjectsFromGroup(groupName);
        foreach (GameObject obj in gameObjects)
        {
            if (obj.GetComponent<Rigidbody2D>() != null)
            {
                StartCoroutine(KinematicTransformCorourine(obj.transform));
            }
            else
            {
                StartCoroutine(TransformCoroutine(obj.transform));
            }
        }
    }

    IEnumerator TransformCoroutine(Transform target)
    {
        Vector3 startPos = target.position;
        Vector3 endPos = startPos + offset;
        float elapsedTime = 0f;
        while (elapsedTime < durationSeconds)
        {
            float t = elapsedTime / durationSeconds;
            float curveValue = curve.Evaluate(t);
            target.position = MyLerp(startPos, endPos, curveValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        target.position = endPos; // Ensure it ends at the exact position.
    }

    IEnumerator KinematicTransformCorourine(Transform target)
    {
        Vector3 startPos = target.position;
        Vector3 endPos = startPos + offset;
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        float elapsedTime = 0f;
        while (elapsedTime < durationSeconds)
        {
            float t = elapsedTime / durationSeconds;
            float curveValue = curve.Evaluate(t);
            rb.MovePosition(MyLerp(startPos, endPos, curveValue));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        target.position = endPos; // Ensure it ends at the exact position.
    }

    Vector3 MyLerp(Vector3 A, Vector3 B, float t)
    {
        return A + (B - A) * t;
    }
}
