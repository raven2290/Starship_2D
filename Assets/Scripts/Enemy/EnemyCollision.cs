using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	[Header("Damage")]
	public int damageAmount = 10;
	public float knockbackForce = 5f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		// damage player
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
			if (hp != null)
			{
				hp.TakeDamage(damageAmount);
			}
		}

		//knockback
		Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
		if(rb != null)
		{
			Vector2 dir = (collision.transform.position - transform.position).normalized;
			rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
		}
	}
}
