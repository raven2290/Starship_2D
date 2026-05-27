using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStarship : Enemy
{
    [Header("Enemy Starship Settings")]
    public float moveSpeed;
    public float rotationSpeed;

	[Header("Weapons")]
	public float fireRate; // how often the enemy can fire
	private float nextFireTime; // time when the enemy can fire again
	public GameObject bulletPrefab; // the bullet prefab to instantiate



	void Start()
	{
		HandleEnemyAttacks();
		HandleEnemyMovements();
	}

	void HandleEnemyAttacks()
	{
		// fire bullets at a regular interval based on the fire rate
		if (Time.time >= nextFireTime)
		{
			nextFireTime = Time.time + fireRate;
			FireBullet();
		}
	}

	void FireBullet()
	{
		/*if (player == null) return;
		//calculate direction to player
		Vector2 direction = (Pawn.transform.position - transform.position).normalized;
		// creater rotation for the bullet to face the player
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 to adjust for the default orientation of the bullet
		//spawn the bullet
		Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));*/
	}

	void HandleEnemyMovements()
	{
		// Example movement pattern: move forward and rotate slowly
		transform.position += transform.up * moveSpeed * Time.deltaTime; // move forward
		transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // rotate
	}

	// TODO: add weapons functions and change sprite bullet color to red
}
