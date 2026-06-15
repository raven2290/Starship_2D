using UnityEngine;

public class Astroid : MonoBehaviour
{
	[Header("Movement")]
	public float driftSpeed = 3f;
	public float rotationSpeed = 50f;

	[Header("Homing")]
	public float homingStrength = 0.25f; // 0 = no homing, 1 = strong homing

	[Header("Despawn")]
	public float maxDistanceFromPlayer = 120f;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		// Give asteroid a random drift direction
		Vector2 randomDir = Random.insideUnitCircle.normalized;
		rb.linearVelocity = randomDir * driftSpeed;

		// Random rotation
		rb.angularVelocity = rotationSpeed * (Random.value > 0.5f ? 1 : -1);
	}

	void Update()
	{
		if (GameManager.instance.player == null)
			return;

		Transform player = GameManager.instance.player.transform;

		// 1. Light homing toward player
		Vector2 toPlayer = (player.position - transform.position).normalized;
		Vector2 newDir = Vector2.Lerp(rb.linearVelocity.normalized, toPlayer, homingStrength * Time.deltaTime);

		rb.linearVelocity = newDir * driftSpeed;

		// 2. Auto-despawn if too far
		float dist = Vector3.Distance(transform.position, player.position);

		if (dist > maxDistanceFromPlayer)
		{
			Destroy(gameObject);
			return;
		}
	}
}
