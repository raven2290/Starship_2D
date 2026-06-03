using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[Header("Health Settings")]
	public float maxHealth;
	private float currentHealth;

	

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		currentHealth = maxHealth;
		Debug.Log("Max health is " + maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		Debug.Log("Took " + amount + " damage, current health is " + currentHealth);
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		Death deathcomponent = GetComponent<Death>();
		// if health reaches 0, call the Die() method on the Death component
		if (deathcomponent != null) 
		{
			if (currentHealth <= 0)
			{ deathcomponent.Die();}
		}
	}


}