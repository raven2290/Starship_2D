using UnityEngine;

public class BulletMover : MonoBehaviour
{
	public float moveSpeed;
	private bool isMoving = false;

	void Start()
	{
		// Optionally, you could add some initialization code here
	}
	void Update()
	{
		if (isMoving)
		{
			transform.position += transform.up * moveSpeed * Time.deltaTime; // move in the direction the bullet is facing
		}
	}

	public void StartMoving()
	{ 
		isMoving = true;
	}
}
