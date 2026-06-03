using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bulletToShoot;
    public Transform firePoint;

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
