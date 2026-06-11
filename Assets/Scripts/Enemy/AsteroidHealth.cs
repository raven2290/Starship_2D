using UnityEngine;

public class AsteroidHealth : Health
{

	protected override void Die()
	{
		Debug.Log($"{gameObject.name} destroyed!");
		GameManager.instance.AddScore(5);
		Destroy(gameObject);
	}
}
