using UnityEngine;

public class EnemyHealth : Health
{
	
	protected override void Die()
	{
		if (KillTracker.instance != null)
		{
			GameManager.instance.AddKill();
			Debug.Log($"{gameObject.name} destroyed!");
			GameManager.instance.AddScore(10);
		}
		Destroy(gameObject);
	}
}