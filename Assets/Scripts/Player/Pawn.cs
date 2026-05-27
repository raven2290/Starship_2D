using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
	public abstract void MoveForward();

	public abstract void MoveBackward();

	public abstract void RotateClockwise();

	public abstract void RotateCounterClockwise();

	public abstract void Thrust();

	public abstract void Teleport();

	public abstract void Fire();
}
