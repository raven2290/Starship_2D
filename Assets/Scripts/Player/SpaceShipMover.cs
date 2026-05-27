using UnityEngine;

public class SpaceShipMover : MonoBehaviour
{
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    public void Move(Vector3 moveVector, float moveSpeed)
	{
		tf.position += (moveVector * moveSpeed) * Time.deltaTime;
	}

	public void Rotate(float angle, float rotationSpeed)
	{
		tf.Rotate(0, 0, angle * rotationSpeed * Time.deltaTime);
	}
}
