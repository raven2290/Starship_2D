using UnityEngine;

public class EnemyDeath : Death
{
	public override void Die()
	{
		Destroy(gameObject);
		Debug.Log(gameObject.name + " has died.");
	}

}
