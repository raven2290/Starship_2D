using UnityEngine;

public class BulletWeapon : WeaponBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;

	public override void Fire()
	{
		if (Time.time < nextFireTime) return;
		Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
		GameManager.instance.PlayBullet();

		nextFireTime = Time.time + fireRate;
	}
}
