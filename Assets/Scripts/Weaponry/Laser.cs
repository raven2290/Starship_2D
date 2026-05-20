using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public float speed;
	public float damage;

	private void Update()
	{
		transform.position += transform.up * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// apply damage if it has a health component
		// other.getComponent<Health>()?.TakeDamage(damage);

		Destroy(gameObject);
	}
}
