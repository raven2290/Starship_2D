using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public float maxHealth;
	private float currentHealth;

	void Start()
	{
		currentHealth = maxHealth; // Initialize current health to max health at the start
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		Debug.Log(gameObject.name + " took " + damage + " damage, current health is " + currentHealth);
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		DestructionTracker.Instance.AddKill();
		Destroy(gameObject);
	}
}