using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public bool destroyOnHit = true;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//check if target has health
		EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
		AsteroidHealth asteroid = collision.gameObject.GetComponent<AsteroidHealth>();
		MeteorHealth meteor = collision.gameObject.GetComponent<MeteorHealth>();

		if (enemy != null)
		{
			enemy.TakeDamage(damageAmount);
		}
		else if (asteroid != null)
		{
			asteroid.TakeDamage(damageAmount);
		}
		else if (meteor != null)
		{
			meteor.TakeDamage(damageAmount);
		}

		if (destroyOnHit)
			Destroy(gameObject);
	}

}

