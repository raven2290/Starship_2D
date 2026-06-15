using UnityEngine;

public class BulletCollider : MonoBehaviour
{
	public bool useTrigger = true;
	public int damage = 10;

	private Collider2D col;

	private void Awake()
	{
		col = GetComponent<Collider2D>();
		ApplyColliderMode();
	}

	public void SetTriggerMode(bool isTrigger)
	{
		useTrigger = isTrigger;
		ApplyColliderMode();
	}

	private void ApplyColliderMode()
	{
		col.isTrigger = useTrigger;
	}

	// -------------------------
	// TRIGGER MODE
	// -------------------------
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!useTrigger) return;

		// Ignore player completely
		if (other.CompareTag("Player"))
			return;

		HandleHit(other.gameObject);
	}

	// -------------------------
	// COLLISION MODE
	// -------------------------
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (useTrigger) return;

		// Ignore player completely
		if (collision.gameObject.CompareTag("Player"))
			return;

		HandleHit(collision.gameObject);
	}

	// -------------------------
	// SHARED DAMAGE LOGIC
	// -------------------------
	private void HandleHit(GameObject hitObject)
	{
		// Ignore meteors (bullets do nothing)
		if (hitObject.CompareTag("Meteor"))
			return;

		// Enemy ships
		if (hitObject.CompareTag("Enemy"))
		{
			Health h = hitObject.GetComponent<Health>();
    if (h != null)
        h.TakeDamage(damage);

    GameManager.instance.AddScore(10); // add points per kill
    GameManager.instance.AddKill(); // optional if you track kills
    Destroy(gameObject);
    return;
		}

		// Asteroids
		if (hitObject.CompareTag("Asteroid"))
		{
			Health h = hitObject.GetComponent<Health>();
			if (h != null)
				h.TakeDamage(damage);

			Destroy(gameObject);
			return;
		}

		// Ignore EVERYTHING ELSE
		// (walls, player, enemy-player collisions, etc.)
	}
}