using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
		Destroy(gameObject);
		Debug.Log("Player has died.");
	}
}
