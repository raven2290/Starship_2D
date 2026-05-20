using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public bool selfDestructionOnCollision = false;
    public float damageDone;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// get the pawn on other object
		EnemyHealth Health = collision.gameObject.GetComponent<EnemyHealth>();

		if (Health != null)
		{
			Health.TakeDamage(damageDone);
		}
		if (selfDestructionOnCollision)
		{
			Destroy(gameObject);
		}

	}
}
