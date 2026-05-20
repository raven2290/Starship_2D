using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			DestructionTracker.Instance.AddKill();
			Destroy(gameObject);
		}
	}
}
