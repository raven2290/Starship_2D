using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
	[Header("Movement Settings")]
	public float moveSpeed; // speed of the player's movement
	public float rotationSpeed; // speed of the player's rotation
	public float tuboSpeed;
	

	public abstract void MoveForward();

	public abstract void MoveBackward();

	public abstract void RotateClockwise();

	public abstract void RotateCounterClockwise();
	public abstract void Turbo();

	public abstract void Thrust();

	public abstract void Teleport();

	public abstract void Shoot();

	
}
