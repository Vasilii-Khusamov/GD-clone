using System.Collections;
using UnityEngine;

public class ColorTrigger : Trigger
{
    [SerializeField] private string groupName; // group of objects to change color.
    [SerializeField] private Color targetColor;
    [SerializeField] private float durationSeconds = 1f; // duration of the color change.
    [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1); // interpolation curve for the color change.
    override public void Activate()
    {
        GameObject[] gameObjects = GetObjectsFromGroup(groupName);
        foreach (GameObject obj in gameObjects)
        {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                StartCoroutine(RecolorRoutine(renderer));
            }
        }
    }
    IEnumerator RecolorRoutine(SpriteRenderer renderer)
    {
        Color startingColor = renderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < durationSeconds)
        {
            float t = elapsedTime / durationSeconds;
            t = curve.Evaluate(t);
            renderer.material.color = Color.Lerp(startingColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        renderer.material.color = targetColor;
    }
}
