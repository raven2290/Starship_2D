using UnityEngine;

public class DeathRespawn : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Die()
	{
		transform.position = Vector3.zero; // Respawn at the origin (you can change this to a specific respawn point)
	}
}
