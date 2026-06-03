using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damage;
	public bool selfDestroy;
   

    [Header("reference")]
    private Rigidbody2D rb;
    public Health healthComponent;
    public EnemyHealth enemyHealthComponent;

    public void Start()
	{

		if (GameManager.instance != null)
		{
			GameManager.instance.damageOnCollision.Add(this);
		}


		rb = GetComponent<Rigidbody2D>();
		healthComponent = GetComponent<Health>();
		enemyHealthComponent = GetComponent<EnemyHealth>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Health otherHealth = other.GetComponent<Health>();
		if (otherHealth != null) 
		{
			otherHealth.TakeDamage(damage);
		}
		// health reaches 0
		/*if (otherHealth = 0)
		{
			Death otherDeathComponent = other.GetComponent<Death>();
			if (otherDeathComponent != null)
			{
				otherDeathComponent.Die();
				Destroy(gameObject);
				Debug.Log(gameObject.name + " has died");
			}
		}*/
		
		
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Death otherDeathComponent = other.gameObject.GetComponent<Death>();

		if (otherDeathComponent != null) 
		{
			otherDeathComponent.Die();
			Destroy(gameObject);
			Debug.Log("You Destroyed " +  gameObject.name);
		}
	}
}
