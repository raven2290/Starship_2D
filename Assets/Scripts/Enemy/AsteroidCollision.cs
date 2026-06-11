using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
	[Header("Damage")]
	public int damageAmount = 15;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
			if (hp != null)
			{
				hp.TakeDamage(damageAmount);
			}
		}
	}
}
