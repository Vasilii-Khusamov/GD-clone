using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform followTransform;
	public Vector3 cameraOffset;
	
	void Update()
	{
		if (followTransform == null)
		{
			return;
		}
		transform.position = new Vector3(followTransform.position.x - cameraOffset.x, followTransform.position.y - cameraOffset.y, transform.position.z);
	}
}