using UnityEngine;

public class Bullet : WeaponBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;

	public override void FireDown()
	{
		TryShoot();
	}
	public override void FireHeld()
	{
		
	}

	public override void FireUp()
	{

	}

	void TryShoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// get the pawn on other object
		Health otherObjectHealth = collision.gameObject.GetComponent<Health>();
		if (otherObjectHealth != null)
		{
			otherObjectHealth.TakeDamage(10); // example damage value
		}
	}
}
