using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageOnCollision damageComponent;
    public BulletMover bulletMoverComponent;
	public float damage;
	public bool destroyOnHit = true;

	public void Awake()
	{
		damageComponent = GetComponent<DamageOnCollision>();
		bulletMoverComponent = GetComponent<BulletMover>();
	}

	public void ActivateBullet()
	{
		bulletMoverComponent.StartMoving();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject other = collision.gameObject;

		// Try to get ANY Health component (Enemy, Asteroid, Meteor, etc.)
		Health targetHealth = other.GetComponent<Health>();

        if (targetHealth != null)
        {
            // Deal damage
            targetHealth.TakeDamage(damage);

            // If the object died, award score
            if (targetHealth.currentHealth <= 0)
            {
                AwardScore(other);
			}
        }

        // Destroy bullet after hit
        if (destroyOnHit)
			Destroy(gameObject);
    }

    void AwardScore(GameObject obj)
	{
		if (obj.CompareTag("Enemy"))
			GameManager.instance.AddScore(10);

		else if (obj.CompareTag("Asteroid"))
			GameManager.instance.AddScore(5);

		else if (obj.CompareTag("Meteor"))
			GameManager.instance.AddScore(25);
	}
	
}
