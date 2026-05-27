using UnityEngine;

public class Health : MonoBehaviour
{
	[Header("Health Settings")]
	public float maxHealth;
	private float currentHealth;

	[Header("regen Settings")]
	public float regenRate;
	public float regenDelay;
	private float lastDamageTime;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Max health is " + maxHealth);
	}

    // Update is called once per frame
    void Update()
    {
		HandleRegen();
    }

    public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		Debug.Log("Took " + damage + " damage, current health is " + currentHealth);
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void heal(float healAmount)
	{
		currentHealth += healAmount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		Debug.Log("Healed " + healAmount + " health, current health is " + currentHealth);
	}

	private void Die()
	{
		Death deathComponent = GetComponent<Death>();
		Debug.Log("Player has died.");
		// Implement death behavior here (e.g., respawn, game over screen, etc.)
		if (deathComponent != null)
		{
			deathComponent.Die();
		}
		else
		{
			Debug.LogWarning("No Death component found on " + gameObject.name);
		}
	}

	private void HandleRegen()
	{
		if (Time.time - lastDamageTime > regenDelay)
		{
			currentHealth += regenRate * Time.deltaTime;
			currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		}
	}
}
