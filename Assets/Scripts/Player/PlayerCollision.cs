using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Damage")]
    public int enemyDamage = 15;
    public int asteroidDamage = 10;
    public int meterDamage = 10;
    public float knockbackForce = 5f;

    private PlayerHealth playerHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject other = collision.gameObject;

		Health targetHealth = other.GetComponent<Health>();

		if (other.CompareTag("Meteor"))
		{
            playerHealth.TakeDamage(9999);
            GameManager.instance.ActivateGameOverStateObject();

		}

		if (targetHealth != null)
		{
			if(targetHealth.currentHealth <= 0)
			{
				AwardScore(other);
				Destroy(other);
			}

		}
	}

    void AwardScore(GameObject obj)
    {
		if (obj.CompareTag("Enemy"))
			GameManager.instance.AddScore(15);
		else if (obj.CompareTag("Asteroid"))
			GameManager.instance.AddScore(5);
		else if (obj.CompareTag("Meteor"))
			GameManager.instance.AddScore(100);
	}

    void ApplyKnockback(Collision2D collision)
    {
		if (rb == null) return;

		Vector2 dir = (transform.position - collision.transform.position).normalized;
		rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
	}
}
