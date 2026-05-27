using UnityEngine;

public class StarshipPawn : Pawn
{
    private SpaceShipMover mover; // reference to the SpaceShipMover component for handling movement

	[Header("Starship Settings")]
	public float moveSpeed; // speed of the player's movement
	public float rotationSpeed; // speed of the player's rotation

	private Vector3 randomPosition; // variable to store the random position for teleportation
	private Pawn pawn;





	/*
	[Header("Thruster Effects")]
	public ParticleSystem ThrusterL;
	public ParticleSystem ThrusterR;
	private ParticleSystem.EmissionModule emL;
	private ParticleSystem.EmissionModule emR;*/



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		mover = GetComponent<SpaceShipMover>();
        
        //emL = ThrusterL.emission;
        //emR = ThrusterR.emission;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void MoveForward()
	{
		if (mover != null)
			mover.Move(transform.forward, moveSpeed);
	}

	public override void MoveBackward()
	{
		if (mover != null)
			mover.Move(-transform.up, moveSpeed);
	}

	public override void  RotateClockwise()
	{
		if (mover != null)
			mover.Rotate(1f, rotationSpeed);
	}

	public override void RotateCounterClockwise()
	{
		if (mover != null)
			mover.Rotate(-1f, rotationSpeed);
	}

	public override void Thrust()
	{
		
			// Implementation for thrusting
	}

	public override void Fire()
	{
		
	// Implementation for firing weapons
	}

	public override void Teleport()
	{
		Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
		pawn.transform.position = randomPosition;
	}
}
