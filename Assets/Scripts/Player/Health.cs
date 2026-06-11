using UnityEngine;

public abstract class Health : MonoBehaviour
{
	public float maxHealth = 50f;
	public float currentHealth;

	protected virtual void Start()
	{
		currentHealth = maxHealth;
		Debug.Log($"{gameObject.name} Health initialized to {currentHealth}");
	}

	// Must be virtual or abstract for override to work
	public virtual void TakeDamage(float amount)
	{
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		Debug.Log($"{gameObject.name} took {amount} damage, current health is {currentHealth}");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	protected abstract void Die();
}
