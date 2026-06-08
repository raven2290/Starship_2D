using UnityEngine;

public class LaserWeapon : WeaponBase
{
	public GameObject laserPrefab;
	public Transform firePoint;

	public override void Fire()
	{
		if (Time.time < nextFireTime) return;
		Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
		GameManager.instance.PlayLaser();

		nextFireTime = Time.time + fireRate;
	}
}
