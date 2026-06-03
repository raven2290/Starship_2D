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

    

	public void heal(float amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		Debug.Log("Healed " + amount + " health, current health is " + currentHealth);
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		Debug.Log("Took " + amount + " damage, current health is " + currentHealth);
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		Death deathcomponent = GetComponent<Death>();
		if (deathcomponent != null)
			{
				if (currentHealth <= 0)
				{ deathcomponent.Die(); }
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
