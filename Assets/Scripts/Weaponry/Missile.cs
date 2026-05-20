using UnityEngine;

public class Missile : WeaponBase
{
    public GameObject missilePrefab;
    public Transform firePoint;
	public Transform target;

	public override void FireDown()
	{
		if (!DestructionTracker.Instance.MissilesUnlocked())
		{
			Debug.Log("Missiles are not unlocked yet!");
			return;
		}
		
		GameObject m = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);

			Missile missile = m.GetComponent<Missile>();
			missile.target = target;
		
	}
	public override void FireHeld()
	{
		// no behavior while held
	}
	public override void FireUp() { }


	Transform FindNearestTarget()
	{
		// find all enemy targets in the scene
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] asteroids= GameObject.FindGameObjectsWithTag("Asteroid");

		Transform nearest = null;
		float nearestDist = Mathf.Infinity;

		//check enemies
		foreach (GameObject e in enemies)
		{
			float dist = Vector3.Distance(transform.position, e.transform.position);
			if (dist < nearestDist)
			{
				nearestDist = dist;
				nearest = e.transform;
			}
		}

		//check asteroids
		foreach (GameObject a in asteroids)
		{
			float dist = Vector3.Distance(transform.position, a.transform.position);
			if (dist < nearestDist)
			{
				nearestDist = dist;
				nearest = a.transform;
			}
		}

		return nearest;
	}

	private void Start()
	{
		// auto-lock nearest target
		target = FindNearestTarget();
		Destroy(gameObject);
	}
}
