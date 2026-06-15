using UnityEngine;

public class StarshipPawn : Pawn
{

	public Shooter Shooter; // stays public so you can still see it in Inspector

	void Awake()
	{
		if (Shooter == null)
		{
			Shooter = GetComponent<Shooter>();
		}

		if (Shooter == null)
		{
			Shooter = GetComponentInChildren<Shooter>();
		}

		if (Shooter == null)
		{
			Shooter = GetComponentInParent<Shooter>();
		}

		if (Shooter == null)
		{
			Debug.LogError("Shooter component missing on Player!");
		}


	}

	public override void Shoot()
	{
		if (Shooter == null)
		{
			Debug.LogError("Shooter reference missing!");
			return;
		}

		if (Shooter.bulletToShoot == null)
		{
			Debug.LogWarning("Bullet prefab missing — reassigning...");
			Shooter.bulletToShoot = Resources.Load<Bullet>("Prefabs/Bullet");
		}

		Bullet bulletInstance = Instantiate(
			Shooter.bulletToShoot,
			Shooter.firePoint.position,
			Shooter.firePoint.rotation
		);

		bulletInstance.ActivateBullet();
	}
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

	public override void Teleport()
	{
		Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
		transform.position = randomPosition;
	}
}
