using UnityEngine;

public class BulletCollider : MonoBehaviour
{
	public bool useTrigger = true; // switch this ON/OFF when spawning
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

		HandleHit(other.gameObject);
	}

	// -------------------------
	// COLLISION MODE
	// -------------------------
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (useTrigger) return;

		HandleHit(collision.gameObject);
	}

	// -------------------------
	// SHARED DAMAGE LOGIC
	// -------------------------
	private void HandleHit(GameObject hitObject)
	{
		// Ignore self or friendly layers if needed
		if (hitObject.CompareTag("Player"))
			return;

		// Meteor = instant destruction (no damage system)
		if (hitObject.CompareTag("Meteor"))
		{
			// Meteor kills player, but bullets should NOT affect meteors
			return;
		}

		// Asteroid = takes damage (if you want it to)
		if (hitObject.CompareTag("Asteroid"))
		{
			Health h = hitObject.GetComponent<Health>();
			if (h != null)
				h.TakeDamage(damage);

			Destroy(gameObject);
			return;
		}

		// Enemy ships = take damage
		if (hitObject.CompareTag("Enemy"))
		{
			Health h = hitObject.GetComponent<Health>();
			if (h != null)
				h.TakeDamage(damage);

			Destroy(gameObject);
			return;
		}

		// Generic fallback for anything with Health
		Health generic = hitObject.GetComponent<Health>();
		if (generic != null)
		{
			generic.TakeDamage(damage);
			Destroy(gameObject);
			return;
		}

		// If it hits something irrelevant, just destroy the bullet
		Destroy(gameObject);
	}

}
