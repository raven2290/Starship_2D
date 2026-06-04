using UnityEngine;

public class CameraController : MonoBehaviour
{
    
	private Transform target;   // Optional: You can add an offset to position the camera slightly above
	public float smoothSpeed;
	private Vector3 offset;		// Offset to keep the camera slightly above the player
	
	
	void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

		transform.position = smoothedPos; // this moves the camera, not the player

		Debug.Log("camera is attached to " + gameObject.name);
	}

	public void SetTarget(Transform newTarget)
	{
		if (newTarget == null)
		{
			Debug.LogError("Player GameObject not assigned in CameraController.");
			return;
		}
		target = newTarget;
		// Calculate the initial offset based on the camera's starting position and the player's position
		offset = transform.position - target.transform.position;
		Debug.Log("camera is following " + target.name + " at " + offset);
	}
}
