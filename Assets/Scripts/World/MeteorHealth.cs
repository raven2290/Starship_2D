using UnityEngine;

public class MeteorHealth : Health
{
	protected override void Die()
	{
		GameManager.instance.AddScore(25);
		Destroy(gameObject);
	}
}
