using UnityEngine;

public class ChargeLaser : WeaponBase
{
	[Header("Charge Settings")]
	public float maxChargeTime = 3f; // Maximum time to fully charge the laser
	public float minChargeToFire = 0.2f; // Minimum charge time required to fire the laser
	public AnimationCurve chargePowerCurve; // Optional curve to control how charge time translates to power

	[Header("Laser Settings")]
	public GameObject laserPrefab; // Prefab for the laser projectile
	public Transform firePoint; // Point from which the laser will be fired
	public float baseDamage; // Base damage of the laser projectile
	public float maxDamage; // Maximum damage when fully charged

	private float currentCharge; // Current charge level of the laser
	private bool isCharging = false; // Flag to indicate if the laser is currently charging
	

	public override void FireDown()
	{
		// spacebar pressed, start charging
		isCharging = true;
		currentCharge = 0f; // reset charge when starting to fire
		Debug.Log("Started charging laser.");
	}

	public override void FireHeld()
	{
		if (isCharging)
		{
			currentCharge += Time.deltaTime;
			currentCharge = Mathf.Clamp(currentCharge, 0f, maxChargeTime);
			Debug.Log($"Charging laser: {currentCharge:F2} seconds");
			// You can add visual feedback for charging here (e.g., change color or size of the fire point)
		}
	}

	public override void FireUp()
	{
		// spacebar released, fire the laser if it has enough charge
		if (!isCharging) return;

		isCharging = false;

		Debug.Log("firing laser at " + currentCharge + " charge");

		GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

		// pass value to laser script
		ChargeProjectile proj = laser.GetComponent<ChargeProjectile>();
		if (proj != null)
		{
			proj.SetCharge(currentCharge);
		}
	}

	/*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			isCharging = true;
			
		}
		if (isCharging && Input.GetKey(KeyCode.Space))
		{
			currentCharge += Time.deltaTime;
			currentCharge = Mathf.Clamp(currentCharge, 0f, maxChargeTime);
			// You can add visual feedback for charging here (e.g., change color or size of the fire point)
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			FireLaser();
			isCharging = false;
		}
	}*/

	/*void FireLaser()
	{
		if (currentCharge < minChargeToFire)
		{
			return; //not enough charge to fire

			float chargePercent = currentCharge / maxChargeTime;

			// use cureve if assined otherwise linear
			float powerMultiplier = chargePowerCurve != null && chargePowerCurve.keys.Length > 0
			? chargePowerCurve.Evaluate(chargePercent)
			: chargePercent;

			float finalDamage = Mathf.Lerp(baseDamage, maxDamage, powerMultiplier);

			//spawn laser
			GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

			// apply damage to laser script
			/*Laser Projectile proj = laser.GetComponent<Laser>();
			if (Projectile != null)
			{
				proj.damage = finalDamage;
			}
		}
	}*/
}
