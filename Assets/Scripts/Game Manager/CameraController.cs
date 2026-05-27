using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
							  // Optional: You can add an offset to position the camera slightly above
	private Vector3 offset; // Offset to keep the camera slightly above the player
	void Start()
	{
		if (player == null)
		{
			Debug.LogError("Player GameObject not assigned in CameraController.");
			return;
		}
		// Calculate the initial offset based on the camera's starting position and the player's position
		offset = transform.position - player.transform.position;
	}
	void LateUpdate()
	{
		if (player == null) return;
		// Update the camera's position to follow the player, maintaining the offset
		Vector3 newPosition = player.transform.position + (Vector3)offset;
		transform.position = newPosition;
	}
}
