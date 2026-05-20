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

}
