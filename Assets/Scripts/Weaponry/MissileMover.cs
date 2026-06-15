using UnityEngine;

public class MissileMover : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 200f;
    public float lifeTime = 5f;
    public int damage = 50;

    private Transform target;

	private void Start()
	{
		FindNearestTarget();
		Destroy(gameObject, lifeTime);
	}

	private void Update()
	{
		if (target == null)
		{
			FindNearestTarget();
			transform.Translate(Vector3.up * speed * Time.deltaTime);
			return;
		}

		Vector2 direction = (target.position - transform.position).normalized;
		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		transform.Rotate(0, 0, - rotateAmount * rotateSpeed * Time.deltaTime);
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	void FindNearestTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

		float shortest = Mathf.Infinity;
		Transform nearest = null;

		foreach (GameObject e in enemies)
		{
			float dist = Vector2.Distance(transform.position, e.transform.position);
			if (dist < shortest)
			{
				shortest = dist;
				nearest = e.transform;
			}
		}

		foreach (GameObject a in asteroids)
		{
			float dist = Vector2.Distance(transform.position, a.transform.position);
			if (dist < shortest)
			{
				shortest = dist;
				nearest = a.transform;
			}
		}

		target = nearest;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
		{
			Health h = other.GetComponent<Health>();
			if (h != null)
				h.TakeDamage(damage);

			Destroy(gameObject);
		}
	}
}
