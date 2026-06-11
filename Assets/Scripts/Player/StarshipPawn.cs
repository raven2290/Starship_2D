using UnityEngine;

public class StarshipPawn : Pawn
{

	public Shooter Shooter;
	private Vector3 randomPosition; // variable to store the random position for teleportation
	


	/*
	[Header("Thruster Effects")]
	public ParticleSystem ThrusterL;
	public ParticleSystem ThrusterR;
	private ParticleSystem.EmissionModule emL;
	private ParticleSystem.EmissionModule emR;*/



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		pawnType = PawnType.Player;
		//Instantiate(WeaponManager.instance.weapons[0].gameObject);

		//emL = ThrusterL.emission;
		//emR = ThrusterR.emission;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void MoveForward()
	{
		transform.position += (transform.up * moveSpeed) * Time.deltaTime; // move in the direction the ship is facing
		
	}

	public override void MoveBackward()
	{
		transform.position += -transform.up * moveSpeed * Time.deltaTime; // move in the direction opposite to the ship's facing
	}

	public override void  RotateClockwise()
	{
		transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); // rotate around the Z-axis for 2D rotation
	}

	public override void RotateCounterClockwise()
	{
		transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // rotate around the Z-axis in the opposite direction for 2D rotation
	}

	public override void Turbo()
	{
		//if move foward or backward is being held, move faster in that direction
		if (Input.GetKey(KeyCode.W))
			 transform.position += (transform.up * moveSpeed * tuboSpeed) * Time.deltaTime; // move faster in the direction the ship is facing
		else if (Input.GetKey(KeyCode.S))
			transform.position += (-transform.up * moveSpeed * tuboSpeed) * Time.deltaTime; // move faster in the direction opposite to the ship's facing
	}

	public override void Thrust()
	{
		
	}

	

	public override void Shoot()
	{
		Shooter shooter = GetComponent<Shooter>();
		if (shooter != null)
		{
			Bullet bulletInstance = Instantiate(shooter.bulletToShoot, shooter.firePoint.position, shooter.firePoint.rotation);
			bulletInstance.ActivateBullet();
			Debug.Log("Bullet fired!");
		}
	}

	public override void Teleport()
	{
		Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
		transform.position = randomPosition;
	}
}
