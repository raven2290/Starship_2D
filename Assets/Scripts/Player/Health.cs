using UnityEngine;

public abstract class Health : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	protected virtual void Start()
	{
		currentHealth = maxHealth;
	}
	public virtual void TakeDamage(float amount)
	{
		currentHealth -= amount;
		if (currentHealth < 0)
		{
			Die();
		}
	}
	protected void Die()
	{

	}
}
