using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public bool selfDestructionOnCollision = false;
	private Rigidbody2D rb;
	public float damage;
	private float currentHealth;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			// get the pawn on other object
			Health otherObjectHealth = other.gameObject.GetComponent<Health>();

			if (otherObjectHealth != null)
			{
				otherObjectHealth.TakeDamage(damage);
			}
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
			}
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			// get the pawn on other object
			Health otherObjectHealth = other.gameObject.GetComponent<Health>();

			if (otherObjectHealth != null)
			{
				otherObjectHealth.TakeDamage(damage);
			}
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
