using UnityEngine;

public class PlayerHealth : Health
{
	//[Header("Health Settings")]
	

	[Header("Shield Settings")]
	public float maxShield;
	public float currentShield;


	[Header("regen Settings")]
	public float regenRate;
	public float regenDelay;
	private float lastDamageTime;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected override void Start()
	{
		base.Start();
		currentShield = maxShield;
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

		//healthBar.fillAmount = currentHealth;
	}

	public override void TakeDamage(float amount)
	{
		//Shield starts to take damage
		if (currentShield> 0)
		{
			float ShieldDamage = Mathf.Min(amount, currentShield);
			currentShield -= ShieldDamage;
			amount -= ShieldDamage;

			GameManager.instance.gameplayUI.UpdateShield(currentShield, maxShield);

		}

		// remainining damage to health
		if (amount>0)
		{
			base.TakeDamage(amount);
			GameManager.instance.gameplayUI.UpdateHealth(currentHealth, maxHealth);
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
