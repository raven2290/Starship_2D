using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStarship : MonoBehaviour
{
	public Transform target;
	public float moveSpeed = 5f;
	public float rotationSpeed = 200f;

	void Start()
	{
		if (target == null)
			target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	 void Update()
	{
		if (target == null) return;

		Vector2 direction = (target.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.RotateTowards(
			transform.rotation,
			Quaternion.Euler(0, 0, angle),
			rotationSpeed * Time.deltaTime
		);

		transform.position += transform.up * moveSpeed * Time.deltaTime;
	}
}
