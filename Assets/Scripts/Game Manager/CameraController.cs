using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform target;
	public float smoothSpeed = 5f;
	public Vector3 offset;

	private void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
		offset = transform.position - target.position;
	}
}
