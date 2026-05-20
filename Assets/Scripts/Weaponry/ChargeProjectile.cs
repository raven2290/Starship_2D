using UnityEngine;

public class ChargeProjectile : MonoBehaviour
{
    [Header("Damage Settings")]
    public float baseDamage;
    public float maxDamage;
    private float damage;

    [Header("Speed Settings")]
    public float speed;

    public void SetCharge(float charge)
    {
        float t = charge / 3f; // Assuming max charge time is 3 seconds
        damage = Mathf.Lerp(baseDamage, maxDamage, t);
	}

    void Update()
	{
		transform.position += transform.up * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// apply damage
        var Health = collision.GetComponent<EnemyHealth>();
        if(Health != null) 
            Health.TakeDamage(damage);

        Destroy(gameObject);
	}
}
