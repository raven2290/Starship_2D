using UnityEngine;

public class StarshipPawn : Pawn
{
    
	[Header("Starship Settings")]
	public float moveSpeed; // speed of the player's movement
	public float rotationSpeed; // speed of the player's rotation



	/*
	[Header("Thruster Effects")]
	public ParticleSystem ThrusterL;
	public ParticleSystem ThrusterR;
	private ParticleSystem.EmissionModule emL;
	private ParticleSystem.EmissionModule emR;*/



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	protected override void Start()
    {
        base.Start();
        //emL = ThrusterL.emission;
        //emR = ThrusterR.emission;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Move(Vector3 moveVector)
	{
		transform.position += (moveVector * moveSpeed) * Time.deltaTime;

		// add a thruster effect when moving forward
		float strength = moveVector.magnitude; // strength of the thruster effect based on the movement vector's magnitude
	}

	public override void Rotate(float angle)
	{
		transform.Rotate(new Vector3(0, 0, angle * rotationSpeed) * Time.deltaTime);
	}
}
