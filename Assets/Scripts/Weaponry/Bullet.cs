using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageOnCollision damageComponent;
    public BulletMover bulletMoverComponent;
	public float damage;

	public void Awake()
	{
		damageComponent = GetComponent<DamageOnCollision>();
		bulletMoverComponent = GetComponent<BulletMover>();
	}

	public void ActivateBullet()
	{
		bulletMoverComponent.StartMoving();
	}

	private void OnTriggerEnter(Collider other)
	{

		// Ignore the player
		if (other.CompareTag("Player"))
			return;

		// Damage enemies only
		if (other.CompareTag("Enemy"))
		{
			Health targetHealth = other.GetComponent<Health>();
			if (targetHealth != null)
				targetHealth.TakeDamage(damage);
		}

		// Destroy bullet on ANY valid hit
		Destroy(gameObject);
	}
}
