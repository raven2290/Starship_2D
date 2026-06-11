using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	[Header("Shooting Settings")]
	public GameObject bulletPrefab;
	public Transform firePoint;
	public float bulletSpeed = 10f;
	public float fireCooldown = 1.5f;

	private float fireTimer;

	private void Update()
	{
		fireTimer -= Time.deltaTime;
	}

	public void TryShoot()
	{
		if (fireTimer <= 0f)
		{
			Shoot();
			fireTimer = fireCooldown;
		}
	}

	private void Shoot()
	{
		if (bulletPrefab == null || firePoint == null)
		{
			Debug.LogWarning("EnemyShoot: Missing bulletPrefab or firePoint");
			return;
		}

		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			rb.linearVelocity = firePoint.up * bulletSpeed;
		}
	}
}
