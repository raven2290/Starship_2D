using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bulletToShoot;
    public Transform firePoint;

	void Awake()
	{
		if (bulletToShoot == null)
		{
			bulletToShoot = Resources.Load<Bullet>("Prefabs/Bullet");
			if (bulletToShoot == null)
				Debug.LogError("Shooter could not find Bullet prefab in Resources/Prefabs!");
		}
	}

	public void Shoot()
    {
		if (bulletToShoot != null && firePoint != null)
		{
			Bullet bulletInstance = Instantiate(bulletToShoot, firePoint.position, firePoint.rotation);
			bulletInstance.bulletMoverComponent.StartMoving(); // start movement after firing
			Debug.Log("Bullet fired!");
		}
	}

    public void Shoot(Bullet bulletToShoot)
    {
        Bullet theBullet = Instantiate(bulletToShoot, firePoint.position, firePoint.rotation);
        Debug.Log("bullet Appeared");
	}
}
