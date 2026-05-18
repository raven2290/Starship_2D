using UnityEngine;

public class StarshipPawn : Pawn
{
    public float moveSpeed; // speed of the player's movement
	public float rotationSpeed; // speed of the player's rotation



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Move(Vector3 moveVector)
	{
		transform.position = transform.position = (moveVector * moveSpeed) * Time.deltaTime;
	}

    public override void Rotate(float angle)
	{
		transform.Rotate(new Vector3(0, 0, angle * rotationSpeed) * Time.deltaTime);
	}
}
