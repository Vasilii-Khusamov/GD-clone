using UnityEngine;

public class PortalRotator : MonoBehaviour
{
    public float revolutionsPerSecond;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.back,revolutionsPerSecond * Time.deltaTime * 360);
    }
}
