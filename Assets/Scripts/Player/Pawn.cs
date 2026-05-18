using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
	public abstract void Move(Vector3 moveVector);
	public abstract void Rotate(float angle);

	protected virtual void Start()
	{

	}
}
