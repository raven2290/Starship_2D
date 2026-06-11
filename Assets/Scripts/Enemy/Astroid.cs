using UnityEngine;

public class Astroid : MonoBehaviour
{
	[Header("Asteroid Speed")]
	public float minDriftSpeed;
	public float maxDriftSpeed;

	public float minRotationSpeed;
	public float maxRotationSpeed;

	private Vector2 driftDirection;
	private float driftSpeed;
	private float rotationSpeed;

	void Start()
	{
		// random drift direction
		driftDirection = Random.insideUnitCircle.normalized;
		//random drift speed
		driftSpeed = Random.Range(minDriftSpeed, maxDriftSpeed);
		//random rotation speed
		rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
	}

	void Update()
	{
		// move asteroid
		transform.Translate(driftDirection * driftSpeed * Time.deltaTime, Space.World);
		//rotate asteroid
		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}
}
