using UnityEngine;

public class EnemyDeath : Death
{
	public override void Die()
	{
		GameManager.instance.AddScore(100);
		Destroy(gameObject);
		Debug.Log(gameObject.name + " has died.");
	}

}
