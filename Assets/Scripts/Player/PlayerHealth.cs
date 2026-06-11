using UnityEngine;

public class PlayerHealth : Health
{
	public float currentShield;
	public float maxShield;

	[Header("Regen Settings")]
	public float regenRate = 5f;          // Health per second
	public float regenDelay = 3f;         // Seconds after taking damage before regen starts
	private float lastDamageTime;

	private void Update()
	{
		HandleRegen();
	}

	public override void TakeDamage(float amount)
	{
		// Shield absorbs damage first
		if (currentShield > 0)
		{
			float shieldDamage = Mathf.Min(amount, currentShield);
			currentShield -= shieldDamage;
			amount -= shieldDamage;

			GameManager.instance.gameplayUI.UpdateShield(currentShield, maxShield);
		}

		// Remaining damage affects health
		if (amount > 0)
		{
			currentHealth -= amount;
			currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
			GameManager.instance.gameplayUI.UpdateHealth(currentHealth, maxHealth);
			Debug.Log($"Player took {amount} damage, current health is {currentHealth}");

			if (currentHealth <= 0)
			{
				Die();
			}
		}
	}


    protected override void Die()
    {
        Debug.Log("Player destroyed!");
        GameManager.instance.ActivateGameOverStateObject();
        Destroy(gameObject);
    }

	void HandleRegen()
	{
		// Only regen if enough time has passed since last damage
		if (Time.time - lastDamageTime >= regenDelay && currentHealth < maxHealth)
		{
			currentHealth += regenRate * Time.deltaTime;
			currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
			GameManager.instance.gameplayUI.UpdateHealth(currentHealth, maxHealth);
		}
	}


	public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Healed {amount} health, current health is {currentHealth}");
        GameManager.instance.gameplayUI.UpdateHealth(currentHealth, maxHealth);
    }
}
