using UnityEngine;

public class MissileWeapon : WeaponBase
{
	public GameObject missilePrefab;
	public Transform firePoint;

	public override void Fire()
	{
		if (Time.time < nextFireTime) return;
		Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
		GameManager.instance.PlayMissile();

		nextFireTime = Time.time + fireRate;
	}
}
