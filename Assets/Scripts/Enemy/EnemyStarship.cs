using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStarship : Pawn
{
	[Header("AI Settings")]
	public Transform target;                // Player
	public float detectionRange = 10f;
	public float fireRange = 6f;
	public float fireCooldown = 1.5f;
	private float fireTimer;

	[Header("Patrol Settings")]
	public Transform[] waypoints;
	private int currentWaypoint = 0;
	public float waypointTolerance = 0.5f;

	private EnemyShoot shooter;

	private void Start()
	{
		pawnType = PawnType.Enemy; // auto‑assign
		shooter = GetComponent<EnemyShoot>();

		if (target == null)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
				target = player.transform;

		}
	}

	private void Update()
	{
		if (pawnType != PawnType.Player) return; 
		if (target == null)
			return;

		float distanceToPlayer = Vector2.Distance(transform.position, target.position);

		if (distanceToPlayer <= detectionRange)
		{
			ChasePlayer();
		}
		else
		{
			Patrol();
		}
	}

	private void Patrol()
	{
		if (waypoints.Length == 0)
			return;

		Transform wp = waypoints[currentWaypoint];

		// Move toward waypoint
		MoveForward();
		RotateToward(wp.position);

		// Check if reached waypoint
		float dist = Vector2.Distance(transform.position, wp.position);
		if (dist <= waypointTolerance)
		{
			currentWaypoint++;
			if (currentWaypoint >= waypoints.Length)
				currentWaypoint = 0;
		}
	}

	private void ChasePlayer()
	{
		RotateToward(target.position);
		MoveForward();

		float distance = Vector2.Distance(transform.position, target.position);

		if (distance <= fireRange)
		{
			fireTimer -= Time.deltaTime;
			if (fireTimer <= 0f)
			{
				Shoot();
				fireTimer = fireCooldown;
			}
		}
	}

	private void RotateToward(Vector3 targetPos)
	{
		Vector2 direction = (targetPos - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

		transform.rotation = Quaternion.RotateTowards(
			transform.rotation,
			Quaternion.Euler(0, 0, angle),
			rotationSpeed * Time.deltaTime
		);
	}

	// -------------------------
	// Pawn Overrides
	// -------------------------

	public override void MoveForward()
	{
		transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
	}

	public override void MoveBackward()
	{
		transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
	}

	public override void RotateClockwise()
	{
		transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
	}

	public override void RotateCounterClockwise()
	{
		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}

	public override void Turbo()
	{
		transform.Translate(Vector3.up * tuboSpeed * Time.deltaTime);
	}

	public override void Thrust()
	{
		// optional thruster effect or acceleration logic
	}

	public override void Teleport()
	{
		// optional teleport logic (e.g., random reposition)
	}

	public override void Shoot()
	{
	// Example shooting logic
		Debug.Log("Enemy fired!");
		// Instantiate bullet prefab here
	}

}
