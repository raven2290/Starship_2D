using UnityEngine;

public class MissileWeapon : WeaponBase
{
	public GameObject missilePrefab;
	public Transform firePoint;

	public float fireCooldown = 1.5f;
	private float fireTimer;

	public void Update()
	{
		fireTimer -= Time.deltaTime;
		//not unlocked yet
		//if (!WeaponsManager.instance.UnlockWeapon()) return;

		// fire missile
		//if (WeaponsManager.instance.UnlockWeapon()) 
		{
			Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
			fireTimer = fireCooldown;
		}
	}

	public override void Fire()
	{
		if (Time.time < nextFireTime) return;
		Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
		GameManager.instance.PlayMissile();

		nextFireTime = Time.time + fireRate;
	}
}
